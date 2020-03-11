/*
	REGEX
*/
var emailReg = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
var CFReg = /[A-Z]{6}[\d]{2}[A-Z][\d]{2}[A-Z][\d]{3}[A-Z]/;
var userReg = /^[a-zA-Z0-9-\._]+$/;
var pwdReg = /^[A-Za-z0-9!@#$%^&*()_-]{6,12}$/;
var passReg=  /^[A-Za-z0-9\d=!\-@._*]{7,30}$/;

var i18n = {
    previousMonth : 'Mese precedente',
    nextMonth     : 'Mese successivo',
    months        : ['Gennaio','Febbraio','Marzo','Aprile','Maggio','Giugno','Luglio','Agosto','Settembre','Ottobre','Novembre','Dicembre'],
    weekdays      : ['Domenica', 'Lunedì','Martedì','Mercoledì','Giovedì','Venerdì','Sabato'],
    weekdaysShort : ['Do','Lu','Ma','Me','Gi','Ve','Sa']
};

/*
	CUSTOM FUNCTION
*/
(function($) {
	//SCROLL TO
	$.fn.scrollTo = function( target, options, callback ){
	  if(typeof options == 'function' && arguments.length == 2){ callback = options; options = target; }
	  var settings = $.extend({
	    scrollTarget  : target,
	    offsetTop     : 50,
	    duration      : 500,
	    easing        : 'swing'
	  }, options);
	  return this.each(function(){
	    var scrollPane = $(this);
	    var scrollTarget = (typeof settings.scrollTarget == "number") ? settings.scrollTarget : $(settings.scrollTarget);
	    var scrollY = (typeof scrollTarget == "number") ? scrollTarget : scrollTarget.offset().top + scrollPane.scrollTop() - parseInt(settings.offsetTop);
	    scrollPane.animate({scrollTop : scrollY }, parseInt(settings.duration), settings.easing, function(){
	      if (typeof callback == 'function') { callback.call(this); }
	    });
	  });
	}

	//URL VARS
	String.prototype.getUrlVars = function () {
		var vars = {};
    var parts = this.replace(/[?#&]+([^=&]+)=([^#&]*)/gi, function(m,key,value) {
    	vars[key] = value;
    });
    return vars;
	}
	String.prototype.convertToSlug = function() {
    return this
        //.toLowerCase()
        .replace(/[áàâåãäæ]+/g,'a')
        .replace(/[éèêë]+/g,'e')
        .replace(/[íìîï]+/g,'i')
        .replace(/[óòôøõö]+/g,'o')
        .replace(/[úùûü]+/g,'u')
        .replace(/[ñ]+/g,'n')
        .replace(/[ß]+/g,'ss')
        .replace(/[ç]+/g,'c')        
        .replace(/[^\w ]+/g,'-')
        .replace(/ +/g,'-')
        ;
	}
	//FORM - FORM ELEMENTS ENABLE
	$.fn.enable = function() {	
		if (this.get(0).tagName=='FORM')
			$(':input', this).removeAttr('disabled');
		else
			$(this).removeAttr('disabled');
	};
	
	//FORM - FORM ELEMENTS DISABLE
	$.fn.disable = function() {
		if (this.get(0).tagName=='FORM')
			$(':input', this).attr('disabled', 'disabled');
		else
			$(this).attr('disabled', 'disabled');
	};
	//FORM CHECK REQUIRED FIELDS
	$.fn.checkRequired = function() {
		var _required=true;
		$('.required[data-pristine!="1"]', this).each (function () {
			$(this).removeClass('input_error');
			if ($(this).val()=='') {
				$(this).addClass('input_error');
				_required=false;
			}
		});
		return _required;
	}
})(jQuery);

/*
	MESSAGE #TODO
*/
function printMessage(text){
	alert(text);
}
function showMessage(txt){
	alert(txt);
}


/*
	DATE FUNCTIONS
*/
function valiDate( year, month, day ) {
	source_date = new Date(year,(month-1),day);
	if(year != source_date.getFullYear())
		 return false;

	if(month != source_date.getMonth()+1)
		 return false;

	if(day != source_date.getDate())
		 return false;

	return true;
}

function getAge(dateString) {
	var today = new Date();
  var birthDate = new Date(dateString);
  var age = today.getFullYear() - birthDate.getFullYear();
  var m = today.getMonth() - birthDate.getMonth();
  if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate()))
  	age--;
  return age;
}

/*
	COOKIES
*/
function setCookie( name, value, expires, path, domain, secure )
{
	var today = new Date();
	today.setTime( today.getTime() );

	if ( expires )
	expires = expires * 1000 * 60 * 60 * 24;

	var expires_date = new Date( today.getTime() + (expires) );

	document.cookie = name + "=" +escape( value ) +
					( ( expires ) ? ";expires=" + expires_date.toGMTString() : "" ) +
					( ( path ) ? ";path=" + path : "" ) +
					( ( domain ) ? ";domain=" + domain : "" ) +
					( ( secure ) ? ";secure" : "" );
}

function getCookie(name) {
	var nameEQ = name + "=";
	var ca = document.cookie.split(';');
	for(var i=0;i < ca.length;i++) {
		var c = ca[i];
		while (c.charAt(0)==' ') 
			c = c.substring(1,c.length);
		if (c.indexOf(nameEQ) == 0) 
			return c.substring(nameEQ.length,c.length);
	}
	return null;
}


/****************/
/*	EXTENTIONS	*/
/****************/

/*
	GOOGLE MAPS
*/
var _GMaps = {},
		_GMarkers = {};
		
jQuery.fn.extend({
	initGMap: function(options) { 
		var $that = $(this)
				id = $that.attr('id'),
				$I = $that.next('input'),
				$btPos = $('~[data-type="position"]', $I),
				ll = $I.val();
				$S = null;
				$btLoc = null;
				autocomplete = null;
	
		if(!_.isUndefined($I.data('search'))){
			$S = $('#' + $I.data('search'));
			$btLoc = $('~[data-type="location"]', $S);			
		}
				
		$(this).data({
			'id': id,
			'target': $I
		});		
		
		if (ll!='') {
			l_l = ll.split( ',' );
			zoom = 16;
		}
		
		var initialLocation = new google.maps.LatLng( l_l[0], l_l[1] );
		var myOptions = {
    	zoom: zoom,
    	center: initialLocation,  
    	mapTypeId: google.maps.MapTypeId.ROADMAP
  	};
  	_GMaps[id] = new google.maps.Map( document.getElementById(id), myOptions );
  	
  	google.maps.event.addListener( _GMaps[id], 'click', function( event ) {
  		$that.placeMarker( event.latLng );
		});
		//DRAG event todo
		
		$I.data({
			'target': _GMaps[id]
		});
		
		//EVENTS
		/*$I.on('change', function(event){
			var l_l = $(this).val().split(','),			
					location = new google.maps.LatLng( l_l[0], l_l[1] ),
					$target = $(this).data('target');
					
			$that.placeMarker( location );			
			$target.panTo(location);
		});*/
		
		$btPos.click(function(e){
			e.preventDefault();
			if (!$(this).hasClass('active')){
				if (!_.isNull($S)){
					$S.val('').hide();
					$btLoc.removeClass('active');
					$I.show();
				}
				$btPos.addClass('active');
			}
			getPosition();
		});
		
		if (!_.isNull($btLoc)){
			$btLoc.click(function(e){
				e.preventDefault();
				
				if (!$(this).hasClass('active')){
					$btPos.removeClass('active');
					$I.hide();
					$S.val('').show();
					$btLoc.addClass('active');
				}
			});
			
			//INTI SEARCH
			/*var defaultBounds = new google.maps.LatLngBounds(
				new google.maps.LatLng(ll[0], ll[1])
				);*/
			var options = {
				//bounds: defaultBounds,
				types: [], //'geocode' - address - establishment
				componentRestrictions: {country: 'it'}
			};
			autocomplete = new google.maps.places.Autocomplete($S.get(0), options);
			
			google.maps.event.addListener(autocomplete, 'place_changed', function() {
				var place = autocomplete.getPlace();
				
				if(_.isObject(place.geometry)){
					var $target = $I.data('target');
					
					$target.panTo(place.geometry.location);
					
				}
			});
		}		
		
		if (ll!='') {
			_GMarkers[id] = new google.maps.Marker({
    		position: new google.maps.LatLng(l_l[0], l_l[1]), 
    		map: _GMaps[id]
			});
		}
		
		getPosition = function(e){
		  if (!_.isUndefined(e))
		  	e.preventDefault();
		  
		  var ll = $I.val();
		  
			if (ll!=''){
				var l_l = ll.split(','),			
						location = new google.maps.LatLng( l_l[0], l_l[1] ),
						$target = $I.data('target');
						
				$that.placeMarker( location );			
				$target.panTo(location);
			}
	  }
  },   
  
  placeMarker: function(location) {
  	var id = $(this).data('id'),
  			$target =  $(this).data('target');
  
  	if (!_.isUndefined(_GMarkers[id])) {
			_GMarkers[id].setMap(null);
		}
		
		_GMarkers[id] = new google.maps.Marker({
  		position: location, 
    	draggable: false,
    	map: _GMaps[id]
		});		

		$target.val( location.lat() + ',' + location.lng());
		
		/*google.maps.event.addListener(_GMarkers[id],'dragend',function(event) {
			console.log(event.latLng.lat());
			console.log(event.latLng.lng());
		});*/
  }
});
