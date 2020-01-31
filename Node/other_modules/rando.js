function getRando(options){
    return options[Math.floor(Math.random()*options.length)];
}

exports.randomize = (options) => getRando(options);