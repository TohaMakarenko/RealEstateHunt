var gulp = require('gulp'),
    cache = require('gulp-cached'); //If cached version identical to current file then it doesn't pass it downstream so this file won't be copied 

gulp.task('copy-node_modules', function () {

    try {
        gulp.src('node_modules/requirejs/require.js')
            .pipe(gulp.dest('wwwroot/lib/requirejs'));

        gulp.src('node_modules/bootstrap/dist/**')
            .pipe(gulp.dest('wwwroot/lib/bootstrap'));

        gulp.src('node_modules/vue/dist/**')
            .pipe(gulp.dest('wwwroot/lib/vue'));

        gulp.src('node_modules/lodash/lodash.js')
            .pipe(gulp.dest('wwwroot/lib/lodash/'));

        gulp.src('node_modules/lodash/lodash.min.js')
            .pipe(gulp.dest('wwwroot/lib/lodash/'));

        gulp.src('node_modules/jquery/dist/**')
            .pipe(gulp.dest('wwwroot/lib/jquery'));
    }
    catch (e) {
        return -1;
    }
    return 0;
});