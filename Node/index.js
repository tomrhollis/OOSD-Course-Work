/*
    Personal Node.JS server
    Tom Hollis
*/

// IMPORTS
const dotenv = require('dotenv').config();
const express = require('express');
const session = require('express-session');
const redis = require('redis');
const redisStore = require('connect-redis')(session);
const path = require('path');
const moment = require('moment');
const sequelize = require('sequelize');
const app = express();
const client = redis.createClient();
const bcrypt = require('bcryptjs');

const rando = require("./other_modules/rando");
var greetings = ['Hi', 'Hey', 'Hello', 'Greetings', 'Sup?', 'What is updog?', 'Salutations'];

// Custom log formatting
function sendToLog(message) {
	var todaysDate = moment().format("MMMM DD, YYYY | HH:mm:ss.SS");
	console.log("[" + todaysDate + "] " + message);
}

function makeData(login) { // make the object to send to pages for EJS to slip in
    return {greeting: rando.randomize(greetings), time: moment().format("MMMM DD, YYYY | HH:mm"), username: login}
}


//INITIALIZE DATABASE CONNECTION 
const db = new sequelize('test', process.env.DB_USER, process.env.DB_PW, { 
    host: process.env.DB_HOST, 
    dialect: 'mysql',
    logging: false, // stop spamming the log
    define: {
        timestamps: false // stops sequelize from trying to insert its own fields into the DB
    }
});
const contacts = require('./models/Contact').model(db, sequelize);
const users = require('./models/User').model(db, sequelize);
var usernames = "";

db.sync().then(()=> { // with guidance from https://medium.com/@paigen11/sequelize-the-orm-for-sql-databases-with-nodejs-daa7c6d5aca3
    sendToLog('DB sync successful');
    users.findAll({ attributes: [[db.fn('DISTINCT', db.col('username')), 'username']] }).then((names)=>{ //update the list
        usernames = names.map(value => value.username);
    }); 
});
//END DB SECTION

var port = process.env.PORT;
app.listen(port, () => {
    sendToLog("Started Web Server on port " + port);
});

//CONNECT TO SESSION SERVER (need to have a redis server going -- linux only)
app.use(session({
    secret: process.env.REDIS_SECRET, // @TODO: Look more into what this line does
    store: new redisStore({ host: process.env.REDIS_HOST, port: process.env.REDIS_PORT, client: client,ttl : 260}),
    saveUninitialized: false,
    resave: false
}));

//STATIC PAGES
//app.use(express.static("views", {extensions: ["html"]}));
app.use(express.static("public"));
app.use(express.static("media"));

//DYNAMIC PAGES
app.set("views", path.join(__dirname, "views"));
app.set("view engine", "ejs");

app.get('/', (req, res) => {
    res.render('index', makeData(req.session.username));
});
app.get('/index.html', (req, res) => {
    res.redirect('/');
});
app.get('/about.html', (req, res) => {
    res.render('about', makeData(req.session.username));
});
app.get('/contact.html', (req, res) => {
    res.render('contact', makeData(req.session.username));
});
app.get('/thanks.html', (req, res) => {
    res.render('thanks', makeData(req.session.username));
});
app.get('/login.html', (req, res) => {
    res.render('login', makeData(req.session.username));
});
app.get('/logout.html', (req, res) => {
    req.session.username = "";
    res.redirect('/');
});

//BEGIN FORM PROCESSING SECTION
app.use(express.urlencoded({extended: true}));
app.post('/contactForm', (req, res) => {
    contacts.create(req.body).then(function (contacts) { // with help from https://stackoverflow.com/questions/52161821/insert-a-new-record-in-nodejs-using-sequelize-post-method/52162653
        res.redirect('/thanks.html');
    });
});
app.post('/getContact', (req, res) => {
    contacts.findOne({where: {ContactName: req.body.GetName}, order: [['ContactID', 'DESC']]}).then(function(result) {
        var toSend = makeData();
        sendToLog(JSON.stringify(result));
        toSend.title = "Contact Search Result";
        toSend.text = "<dl><dt>Name:</dt><dd>" + result.ContactName +
                        "</dd><dt>Email:</dt><dd>" + result.ContactEmail +
                        "</dd><dt>Text:</dt><dd>" + result.ContactText + "</dd></dl>";
        res.render('blank', toSend);
    });
});

app.post("/addnew", (req, res) => {
    bcrypt.hash(req.body.password, 10, (err, hashedPW) => {
    
        if (err) throw err;
        var user = {username: req.body.username, password: hashedPW};

        users.create(user).then(function (success) { // with help from https://stackoverflow.com/questions/52161821/insert-a-new-record-in-nodejs-using-sequelize-post-method/52162653
            if (success) { // successful if create returns something, so send back to the main page for now
                req.session.username = req.body.username;
                res.redirect("/");
                users.findAll({ attributes: [[db.fn('DISTINCT', db.col('username')), 'username']] }).then((users)=>{ //update the list
                    usernames = users.map(value => value.username);
                }); 
            } else {
                res.status(400).send('<!DOCTYPE html><html lang="en"><body><h1>400: Database Error</h1></body></html>');
            }
        });
    });
});

//END FORM PROCESSING SECTION


// XMLHTTPRequest PROCESSING SECTION
app.post('/checkUsername', (req, res) => {
    var c = 0;
    if (usernames.includes(req.body.username)){
        c = 1;
    }
    res.status(200).send("" + c);
});

 // XMLHTTPRequest check for correct password
app.post('/checkPassword', (req, res) => {
    if (!usernames) {
        sendToLog("No usernames in the list");
        res.status(200).send("Bad");
    } else {
        users.findOne({where: {username: req.body.username}, attributes: ['password']}).then((pw) => {
            bcrypt.compare(req.body.password, pw.password, (err, result) => {
                if (err) throw err;
                if (result) {
                    res.status(200).send("OK");
                } else {
                    res.status(200).send("Bad");
                }
            });
        });
    }
});

 // Successful login update
app.post('/doLogin', (req, res) => {
    req.session.username = req.body.username;
    res.redirect('/');
});
// END XMLHTTPRequest SECTION


//BEGIN ERROR HANDLING
app.use((req, res, next) => {
    res.status(404).render('404', makeData(req.session.username));
});

app.use(function (err, req, res, next) { //from expressjs.com
    console.error(err.stack);
    res.status(500).send('<!DOCTYPE html><html lang="en"><body><h1>500: Something broke bigtime! What did you do?!</h1></body></html>');
});
//END ERROR HANDLING