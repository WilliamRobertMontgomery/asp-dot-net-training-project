/// <reference path="jquery-1.7.2.js" />

$(document).ready(function () {
	$('nav a').click(function () {
		if (this.className == 'opened') {
			$(window).scrollTop($('.' + this.id).offset().top);
			return false;
		}
		var newArticle = $('<article />');
		if ($.browser.msie && ($.browser.version < '9.0')) newArticle = $('<div />');
		newArticle.hide().addClass(this.id).insertBefore('section footer').load(this.href, endLoadArticle);
		return false;
	});

	$('.close').live('click', function () {
		$('a#' + $(this).parent().attr('class')).removeClass('opened');
		$(this).parent().remove();
		saveHash();
	});

	parseHash();
});

function endLoadArticle(response, status, xhr) {
	if (status == "success") {
		$('a#' + this.className).addClass('opened');
		$(this).prepend('<div class="close">Close</div>').show();
		$(window).scrollTop($(this).offset().top);
		saveHash();
	}
	if (status == "error") {
		$(this).remove();
		alert('При загрузке статьи произошла следующая ошибка: ' + xhr.status + ' ' + xhr.statusText);
	}
}

function parseHash() {
	if (!location.hash) return;
	var array = location.hash.slice(1).split('|');
	for (var i = 0; i < array.length; i++) {
		$('nav #' + array[i]).click();
	}
}

function saveHash() {
	var array = []
	$('section > article:visible, section > div:visible').each(
		function () {
			array.push(this.className);
		}
	);
	location.hash = array.join('|');
}