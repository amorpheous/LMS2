
$(document).ready(function () {
    $('.subitembtn').on('click', function () {
        $('.subitem').toggleClass('hidden');
        $('.module').addClass('hidden');
        $('.activity').addClass('hidden');
        $('.course').removeClass('hidden');
        $('.module').removeClass('highlight');
        $('.course').removeClass('highlight');
    });
});

$(document).ready(function () {
    var message = $('<span class="highlight">Click a course/module name to see its children. To return to the course list, just re-press the current coursename</span>');
    $('.usa').append(message);
    $('input').prop("checked", false);
});

$(document).ready(function () {
    $('.coursename').click(function () {
        if ($(this).parent().find('input').prop("checked") == true)
        {
            $('.module').addClass('hidden');
            $('.activity').addClass('hidden');
            $('.course').removeClass('hidden');
            $('input').prop("checked",false);
        }
        else
        {
            $('.module').addClass('hidden');
            $('.activity').addClass('hidden');
            $('.course').addClass('hidden');
            $(this).parent().removeClass("hidden");
            $(this).parent().find('input').prop("checked",true);
            $(this).parent().nextUntil('.course', '.module').removeClass("hidden");
        }
    });
});

$(document).ready(function () {
    $('.coursenamebox').click(function () {
        if ($(this).prop("checked") == true) {
            $('input').prop("checked", false);
        }
        else {
            $('input').prop("checked", false);
            $(this).prop("checked", true);
        }
    });
});



$(document).ready(function () {
    $('.modulename').click(function () {
        if ($(this).parent().find('input').prop("checked") == true) {
            $('.activity').addClass('hidden');
            $(this).parent().find('input').prop("checked", false);
        }
        else {
            $('.activity').addClass('hidden');
            $('.modulenamebox').prop("checked", false);
            $('.activitynamebox').prop("checked", false);
            $(this).parent().find('input').prop("checked", true);
            $(this).parent().nextUntil('.module', '.activity').removeClass("hidden");
        }
    });
});

$(document).ready(function () {
    $('.modulenamebox').click(function () {
        if ($(this).prop("checked") == true) {
            $('.modulenamebox').prop("checked", false);
        }
        else {
            $('.modulenamebox').prop("checked", false);
            $('.activitynamebox').prop("checked", false);
            $(this).prop("checked", true);
        }
    });
});


$(document).ready(function () {
    $('.activityname').click(function () {
        if ($(this).parent().find('input').prop("checked") == true) {
            $(this).parent().find('input').prop("checked", false);
        }
        else {
            $('.activitynamebox').prop("checked", false);
            $(this).parent().find('input').prop("checked", true);
        }
    });
});

$(document).ready(function () {
    $('.activitynamebox').click(function () {
        if ($(this).prop("checked") == true) {
            $('.activitynamebox').prop("checked", false);
        }
        else {
            $('.activitynamebox').prop("checked", false);
            $('.activitynamebox').prop("checked", false);
            $(this).prop("checked", true);
        }
    });
});