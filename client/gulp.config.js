module.exports = function () {
    var root = '';
    var app = root + 'app/';
    var assets = root + 'assets/';
    var assetsPath = {
        css: assets + 'css/',
        images: assets + 'images/',
    };
    var index = root + 'index.html';
    var webConfig = root + 'Web.config';
    var tsFiles = [
        app + '**/*.ts'
    ];
    var dist = 'dist/';
    var build = {
        path: dist,
        app: dist + 'app/'
    };
    var mainPath = build.path + app + 'main.js';

    var systemJs = {
        builder: {
            normalize: true,
            minify: true,
            mangle: false,
            globalDefs: { DEBUG: false }
        }
    };
    var bundleName = build.path + "bundle.js";
    var filesToCopy = [
        { src: 'resources/**/*.*' },
        // {src:'resources/themes/gentellela/vendors/bootstrap/dist/**/*.*'}
    ];
    var zip = {
        path: "dist/**/*.*",
        archive: "deploy.zip",
        dest: "dist"
    };
    var config = {
        zip: zip,
        files: filesToCopy,
        bundleName: bundleName,
        mainPath: mainPath,
        root: root,
        app: app,
        index: index,
        build: build,
        assetsPath: assetsPath,
        webConfig: webConfig,
        tsFiles: tsFiles,
        systemJs: systemJs
    };

    return config;
};
