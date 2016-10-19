module.exports.config = {
    specs:"app/**/*.spec.js",
    framework: 'jasmine2',
    seleniumAddress: 'http://localhost:4444/wd/hub',

    capabilities: {
        'browserName': 'chrome'
    },
    jasmineNodeOpts: {
        defaultTimeoutInterval: 40000,
        print: function () { }
    },
    onPrepare: function () {
        allScriptsTimeout: 20000;
        getPageTimeout: 20000;
        browser.ignoreSynchronization = true;
        jasmine.DEFAULT_TIMEOUT_INTERVAL = 40000;
        getBaseUrl = function () {
            return 'http://localhost:3000/';
        };
        requirePage = function (name) {
            return require(__dirname + '/pages/' + name);
        };
        requireUtil = function (name) {
            return require(__dirname + '/utils/' + name);
        };
    },
    baseUrl: 'http://localhost:3000/',
    restartBrowserBetweenTests: true,
    useAllAngular2AppRoots: true
};

