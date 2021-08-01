module.exports = {
    outputDir: "../wwwroot/",
    //filenameHashing: false,
    devServer: {
        port: 8080,
        https: true,
        proxy: {
            "": {
                target: 'https://localhost:44301/',
            }
        }
    }
}