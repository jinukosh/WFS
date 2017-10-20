var config = {
    apiurl: "http://localhost/WFS.WebApi/",
    weburl: "http://localhost/WFS.SPA/",

    generateApiUrl: function (serviceUrl) {
        return config.apiurl + serviceUrl;
    }
}