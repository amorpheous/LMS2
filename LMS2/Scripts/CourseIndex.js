$(document).ready(function init() {
    $('.module').addClass('hidden');
    $('.activity').addClass('hidden');
    $('.course').removeClass('hidden');
    $('.module').removeClass('highlight');
    $('.course').removeClass('highlight');


    });

/*$(document).ready(function () {
    $('.course').on('click', function () {
        $('.module').removeClass('highlight');
        $('.course').removeClass('highlight');
        $('.activity').addClass('hidden');
        $(this).addClass('highlight');
//        $(this).find('.photos').show();
    });
});*/
/*
$(document).ready(function () {
    $('.module').on('click', function () {
        $('.module').removeClass('highlight');
        $(this).addClass('highlight');
        //        $(this).find('.photos').show();
    });
});
*/

/*
$(document).ready(function () {
    $('.course').on('mouseleave', function () {
        $(this).removeClass('highlight');
    });
});
*/

$(document).ready(function () {
    var message = $('<span class="highlight">Choose an item to admin or create a new one. To return to the course list, just re-press the hightlighted course</span>');
$('.usa').append(message);
});

$(document).ready(function () {
    $('.course').click(function () {
        if ($(this).hasClass("highlight"))
        {
            $(this).removeClass("highlight");
            $('.module').addClass('hidden');
            $('.activity').addClass('hidden');
            $('.course').removeClass('hidden');
            $('.module').removeClass('highlight');
            $('.course').removeClass('highlight');
        }
        else
        {
            $('.module').addClass('hidden');
            $('.activity').addClass('hidden');
            $('.course').addClass('hidden');
            $(this).removeClass("hidden");
            $(this).addClass("highlight");
            $(this).nextUntil('.course', '.module').removeClass("hidden");
        }
    });
});

$(document).ready(function () {
    $('.module').click(function () {
        $('.activity').addClass('hidden');
        $('.module').removeClass('highlight');
        $(this).addClass('highlight');

        $(this).nextUntil('.module', '.activity').removeClass("hidden");
    });
});
