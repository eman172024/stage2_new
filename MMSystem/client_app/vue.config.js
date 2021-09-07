module.exports = {
    outputDir: "../wwwroot/",
    //filenameHashing: false,
    devServer: {
        port: 8080,
        https: true,
        proxy: {
            "^/api/": {
                target: 'https://localhost:44369/',
            }
        }
    }
}