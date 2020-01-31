/*
	Login script
	
	TODO: Eventually make this independent of the element IDs
*/

function requestUserCount(){
    var xhttp = new XMLHttpRequest();
    xhttp.open("POST", "/checkUsername", false);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send("username=" + document.getElementById('username').value);
    return xhttp.responseText; 
}

function requestValidation(){
    
    var xhttp = new XMLHttpRequest();
    xhttp.open("POST", "/checkPassword", false);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send("username=" + document.getElementById("username").value + "&password=" + document.getElementById("password").value);
    return xhttp.responseText; 
}

function login(){
    var validation = requestUserCount();

    if (validation == "0"){
        window.alert("That username does not exist. Please try again or register");
        return false;
    }

    validation = requestValidation();

    if (validation != "OK" ){
        window.alert("The username and password do not match, please try again");
        return false;
    }
    return true;
}

function register(){
    var validation = requestUserCount();

    if (validation > "0"){
        window.alert("That username already exists. Please try again.");
        return false;
    }

    document.getElementById('loginForm').action = "/addnew";
    return true;
}