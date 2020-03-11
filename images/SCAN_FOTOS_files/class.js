var Main = {
  initialize: function () {
    Main.initGeneral();
    Main.initSite();
  },

  //GENERAL
  initGeneral: function () {

    //MODAL COOKIE
    if (!Main.getCookie("modlocpop")) {
      $.ajax({
        url: 'https://api.ipapi.com/api/check?fields=country_code&access_key=9aca99c47f26119765019f189dd9feac',
        dataType: 'jsonp',
        success: function (json) {
          if ($.inArray(json.country_code, ['US', 'CA', 'MX', 'BM', 'PM']) != -1) {
            $('#cookie-modal').modal('show');
            $('#cookie-modal').on('shown.bs.modal', function () {
              Main.setCookie("modlocpop", 1, 1);
            });
          }
        }
      });

//      $.get('/r/geolocation/', function (data) {
//        if (data == 1) {
//          $('#cookie-modal').modal('show');
//          $('#cookie-modal').on('shown.bs.modal', function () {
//            Main.setCookie("modlocpop", 1, 1);
//          });
//        }
//      }).fail(function (xhr, textStatus, errorThrown) {
//        console.log(xhr.responseText);
//      });
    }

    //PRINTERS
    if ($('#DPT').length) {
      $('.selectpicker').on('changed.bs.select', function (e) {
        var i = $(e.target).parents(".field").index();
        var v = $(e.target).val();

        console.log(i);
        console.log(v);

        $('.download.button').addClass('hide');
        $('.field:gt(' + i + ') .selectpicker option').removeClass("hide");
        $('.field .selectpicker').prop("disabled", "disabled");
        $('.field:lt(' + (i + 2) + ') .selectpicker').prop("disabled", "");
        $('.field:gt(' + i + ') .selectpicker').val("");
        $('.field:gt(' + i + ') .selectpicker option:not([value*="' + v + '"])').addClass("hide");
        $('.download.button[data-value="' + v + '"]').removeClass('hide');
        $('.selectpicker').selectpicker('refresh');
      });
    }

    //VIDEO MODAL
    if ($('.launch-modal').length) {
      $('.launch-modal').on('click', function (e) {
        e.preventDefault();
        var _index = $(this).data('modal-index');
        var $iframe = $('#video-frame-' + _index);
        $('#modal-video-' + _index).modal();
        $('#modal-video-' + _index).on('hidden.bs.modal', function () {
          $iframe.attr('src', "");
        });
        $('#modal-video-' + _index).on('shown.bs.modal', function () {
          if ($iframe.attr('src') == "")
            $iframe.attr('src', $iframe.data('modal-src'));
        });
      });
    }

    //FANCY
    if ($('.fancybox-thumb').length) {
      $('.fancybox-thumb').fancybox({
        prevEffect: 'none',
        nextEffect: 'none',
        helpers: {
          overlay: {
            locked: false
          }
        }
      });
    }
    //CAROUSEL
    if ($('.carousel').length) {
      $('.carousel').carousel({
        interval: 4000
      })
    }
  },

  initSite: function () {
    $('#SLS select[name="language"]').change(function (e) {
      window.location.href = $(this).val();
    });
  },

  getCookie: function (cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
      var c = ca[i];
      while (c.charAt(0) == ' ')
        c = c.substring(1);
      if (c.indexOf(name) == 0)
        return c.substring(name.length, c.length);
    }
    return "";
  },

  setCookie: function (cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
  },

  foo: null
}

$(document).ready(function () {
  Main.initialize();
});
