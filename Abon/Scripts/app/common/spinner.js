commonModule
    .service('spinner',  function () {

        var opts = {
            lines: 11, // The number of lines to draw
            length: 0, // The length of each line
            width: 9, // The line thickness
            radius: 19, // The radius of the inner circle
            color: '#0079C2', // #rbg or #rrggbb
            speed: 1.2, // Rounds per second
            trail: 83, // Afterglow percentage
            shadow: false, // Whether to render a shadow
            corners: 1.0,
            className: 'spinnerk',
            shadowColor: '#DDD'
        };
        var spinner;

        var overlayDiv = $('<div id="overlay"> </div>');

        function start() {
            overlayDiv.appendTo(document.body);
            var target = document.body;
            spinner = new Spinner(opts).spin(target);
        }

        function stop() {
            spinner.stop();
            overlayDiv.remove();
        }

        return {
            start: start,
            stop: stop
        };
    } );
    