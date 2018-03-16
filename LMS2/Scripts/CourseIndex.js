$(document).ready(function () {
    $('.module').addClass('hidden');
    $('.activity').addClass('hidden');
    });

$(document).ready(function () {
    $('.course').on('mouseenter', function () {
        $(this).addClass('highlight');
//        $(this).find('.photos').show();
    });
});

$(document).ready(function () {
    $('.course').on('mouseleave', function () {
        $(this).removeClass('highlight');
    });
});


$(document).ready(function () {
var message = $('<span class="highlight">THIS IS JUST A TEST LINE</span>');
$('.usa').append(message);
});

$(document).ready(function () {
    $('.course').click(function () {
        $(this).nextUntil('.course','.module').toggleClass("hidden");
    });
});

$(document).ready(function () {
    $('.module').click(function () {
        $(this).nextUntil('.module', '.activity').toggleClass("hidden");
    });
});
