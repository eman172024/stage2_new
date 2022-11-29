module.exports = {
    outputDir: "../wwwroot/",
    //filenameHashing: false,
    devServer: {
        port: 8080,
        https: false,
        proxy: {
            "^/api/": {
                //  target: 'https://localhost:44369/',
                target: 'http://localhost:58316/',
                //  target: 'http://172.16.0.12:82/',
                //   target: 'http://mail:82/',
            }
        }
    }
}