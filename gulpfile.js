var gulp = require('gulp');
var less = require('gulp-less');

// LESS をコンパイルする
gulp.task('less', () => {
    gulp.src(['./wwwroot/app/**/*.less', '!./wwwroot/app/**/_*.less'])
        .pipe(less())
        .pipe(gulp.dest('./wwwroot/app'));
});

// watch
gulp.task('watch', () => {
    gulp.watch('./wwwroot/app/**/*.less', () => {
        gulp.run('less');
    });
});

// ビルド
gulp.task('build', ['less']);