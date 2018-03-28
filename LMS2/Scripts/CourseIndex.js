$(document).ready(function () {
    var message = $('<span class="highlight">Click a course/module name to see its children. To return to the course list, just re-press the current coursename</span>');
    $('.inform').append(message);
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
            $(this).parent().find('input').prop("checked", true);
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

///*

///**
// * File: persistent-checkbox.js
// * Date: 28-Dec-2016
// *
// * Distributed under the FreeBSD License:
// *
// * Copyright (c) 2016, Henry Feild
// * All rights reserved.
// * 
// * Redistribution and use in source and binary forms, with or without
// * modification, are permitted provided that the following conditions are met: 
// * 
// * 1. Redistributions of source code must retain the above copyright notice, this
// *    list of conditions and the following disclaimer. 
// * 2. Redistributions in binary form must reproduce the above copyright notice,
// *    this list of conditions and the following disclaimer in the documentation
// *    and/or other materials provided with the distribution. 
// * 
// * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
// * ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
// * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// * 
// * The views and conclusions contained in the software and documentation are those
// * of the authors and should not be interpreted as representing official policies, 
// * either expressed or implied, of the FreeBSD Project. 
// */

///**
// * Provides persistent storage of checkbox status for input checkboxes with
// * non-empty id attributes. These are stored in localStorage, so only browsers
// * that support localStorage will see checkboxes status stored.
// *
// * Usage: Invoke the PersistantCheckboxes function. It will load any saved check
// * boxes and place a listener on checkbox changes, saving the status of every
// * checkbox as it changes. 
// */
//var PersistentCheckboxes = function () {
//    var genKey, load, save, addListeners, init;

//    var PAGE = window.location.href;

//    /**
//     * Generates a key to store information for a checkbox in localStorage. This
//     * is in the format: checkbox:<page>:<id>, where <page> is the URL of the
//     * page and <id> is the checkbox id (passed in as a parameter).
//     * 
//     * @param {string} id The id of the checkbox.
//     * @return A key that should be unique for the given checkbox on the current
//     *         page.
//     */
//    genKey = function (id) {
//        return 'checkbox:' + PAGE + ':' + id;
//    }

//    /**
//     * A listener to be placed on a checkbox. Saves the checked property (true 
//     * or false) of the checkbox provided in localStorage using its id as the 
//     * key. Checkboxes without an id are not saved.
//     *
//     * @param event The triggered event (ignored). 
//     */
//    save = function (event) {
//        // Only inputs with an id will be saved.
//        if (this.id === "") { return; }
//        localStorage.setItem(genKey(this.id), this.checked + "");
//    };

//    /**
//     * Loads any saved checkbox statuses from localStorage.
//     */
//    load = function () {
//        jQuery('input[type="checkbox"]').each(function (i, elm) {
//            // Ignore checkboxes with no id.
//            var key = genKey(elm.id);
//            if (elm.id !== "" && key in localStorage) {
//                elm.checked = localStorage.getItem(key) === "true";
//            }
//        });
//    };

//    /**
//     * Places a listener on checkbox changes, which triggers the save function.
//     */
//    addListeners = function () {
//        jQuery(document).on('change', 'input[type=checkbox]', save);
//    };

//    /**
//     * Loads any saved data and adds listeners for changes to checkboxes.
//     */
//    init = function (options) {
//        // Only supported if localStorage is available.
//        if (typeof (Storage) === "undefined") { return; }
//        load();
//        addListeners();
//    };

//    init();

//    return this;
//};


//// Let's get this party started!
//var persistentCheckboxes;
//jQuery(document).ready(function () {
//    persistentCheckboxes = new PersistentCheckboxes();
//});