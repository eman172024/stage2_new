module.exports = {
    outputDir: "../wwwroot/",
    //filenameHashing: false,
    devServer: {
        port: 8080,
        https: false,
        proxy: {
            "^/api/": {

                target: 'http://localhost:29268/'
            }
        }
    }
}