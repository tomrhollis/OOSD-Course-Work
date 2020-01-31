// Author: Tom Hollis
// Inspired/informed by https://medium.com/@paigen11/sequelize-the-orm-for-sql-databases-with-nodejs-daa7c6d5aca3


exports.model = (db,sequelize) => { 
    return db.define('contacts', {
        ContactID: {
            type: sequelize.INTEGER,
            primaryKey: true,
            autoIncrement: true
        },
        ContactName: { 
            type: sequelize.STRING,
            allowNull: false
        },        
        ContactEmail: {
            type: sequelize.STRING,
            allowNull: false           
        },
        ContactText: {
            type: sequelize.STRING,
            allowNull: true           
        }
    });
};