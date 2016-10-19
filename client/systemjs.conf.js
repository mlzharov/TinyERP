// This config is used during development and build phase only
// It will not be available on production

var SystemConfig = (function() {
    // List your node_modules packages here
    var packages = [
        'angular2',
        'rxjs',
        'ng2-translate',
        'hammerjs', 
        'ng2-bs3-modal',
        'es6-shim',
        'systemjs'
    ];

    var config = {
        defaultJSExtensions: true,
        baseUrl: '.',
        paths: {
            'n:*': 'node_modules/*',
            hammerjs: 'node_modules/hammerjs/hammer.js'
        },
        map: {
            'rxjs': 'node_modules/rxjs',
            'ng2-translate': 'node_modules/ng2-translate',
            'angular2-jwt': 'node_modules/angular2-jwt/angular2-jwt',
            'angular2-modal': 'node_modules/angular2-modal/dist/commonjs/angular2-modal',
            'ng2-bs3-modal': 'node_modules/ng2-bs3-modal',
            'es6-shim':'node_modules/es6-shim',
            'systemjs':'node_modules/systemjs'
        },
        packages: {
            'app': {
                format: 'register',
                defaultExtension: 'js'
            },
            'test': {
                format: 'register',
                defaultExtension: 'js'
            },
            'angular2-jwt': {
                'defaultExtension': 'js'
            },
            'angular2-modal': {
                'defaultExtension': 'js'
            }
        }
    };

    for (var i = packages.length - 1; i >= 0; i--) {
        var package = packages[i];
        config.map[package] = 'n:' + package;
        config.packages[package] = {
            defaultExtension: 'js'
        };
    }

    System.config(config);
})();
