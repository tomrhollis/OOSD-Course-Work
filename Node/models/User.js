// Author: Tom Hollis
// Inspired/informed by https://medium.com/@paigen11/sequelize-the-orm-for-sql-databases-with-nodejs-daa7c6d5aca3

exports.model = (db, sequelize) => { 
    return db.define('users', {
        userID: {
            type: sequelize.INTEGER,
            primaryKey: true,
            autoIncrement: true
        },
        username: { 
            type: sequelize.STRING,
            allowNull: false
        },        
        password: {
            type: sequelize.STRING,
            allowNull: false           
        }
    });
};