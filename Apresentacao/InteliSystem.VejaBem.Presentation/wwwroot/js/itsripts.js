$(function () {
	$('.dinheiro').maskMoney({ prefix: 'R$ ', allowNegative: true, thousands: '.', decimal: ',', affixesStay: false });
	$('[data-toggle="tooltip"]').tooltip();
	$('.dtcomp').mask('99/9999');
	$('.cpf').mask('999.999.999-99');
	$('.fdata').mask('99/99/9999');
	$('.cep').mask('99.999-999');
	$('.cnpj').mask('99.999.999/9999-99')
	$('.fone').mask('(99) 9999-9999');
	$('.cel').mask('(99) 99999-9999');
	$('.hora').mask('99:99');
	$('.percentual').maskMoney({ sufix: ' %', allowNegative: false, thousands: '', decimal: '.', affixesStay: false });

	$('.calendario').datepicker({
		format: "dd/mm/yyyy",
		weekStart: 0,
		clearBtn: true,
		language: "pt-BR",
		calendarWeeks: true,
		todayHighlight: true
	});

});


/**
* Função de delay de chamada de função.
* Usar preferencialmente em inputs de pesquisa.
* 
* @param {*} options.doneTypingInterval
* 
* @example
* // Input chamando uma função após 1000 ms
* $("#input-id").waitToRun(funcaoASerChamada(), { options.doneTypingInterval: 1000});
* 
*/
$.fn.waitToRun = function (f, options) {
	var typingTimer;
	var settings = $.extend({
		doneTypingInterval: 400,
	}, options);

	$(this).on('keyup', function () {
		clearTimeout(typingTimer);
		typingTimer = setTimeout(f, settings.doneTypingInterval);
	});

	$(this).on('keydown', function () {
		clearTimeout(typingTimer);
	});
}

$(() => {
	// Example starter for disabling form submissions if there are invalid fields
	$('.needs-validation').on('submit',
		function(e) {
			if (this.checkValidity() === false) {
				e.preventDefault();
				e.stopPropagation();
			}
			this.classList.add('was-validated');
		});

	// Bootstrap select
	$('.bs-select').selectpicker({
		style: 'btn'
	});

	function toggleClear(select, el) {
		el.style.display = select.value == '' ? 'none' : 'inline';
		if (select.value == '') {
			select.parentNode.querySelector('.filter-option').classList.remove('mr-4');
		} else {
			select.parentNode.querySelector('.filter-option').classList.add('mr-4');
		}
	}

	for (const el of document.querySelectorAll('select.bs-select, select.bs-select-sm, select.bs-select-lg')) {
		const clearEl = el.parentNode.nextElementSibling;
		if (clearEl && clearEl.classList.contains('bs-select-clear')) {
			toggleClear(el, clearEl);
			el.addEventListener('change',
				function() {
					toggleClear(this, clearEl);
				});
		}
	}

	for (const el of document.querySelectorAll('.bs-select-clear')) {
		el.addEventListener('click',
			function() {
				const select = this.previousElementSibling.querySelector('select');
				$(select).selectpicker('val', '');
				select.dispatchEvent(new Event('change'));
			});
	}
	
	$('.bootstrap-select').on('show.bs.select',
		function() {
			this.querySelector('.dropdown-toggle').classList.add('focus');
		}).on('hide.bs.select',
		function() {
			this.querySelector('.dropdown-toggle').classList.remove('focus');
		});
	for (const el of document.querySelectorAll('select.bs-select')) {
		toggleValidityClass(el);
		el.addEventListener('change', () => toggleValidityClass(el));
	}

	function toggleValidityClass(el) {
		if (el.validity.valid) {
			el.parentNode.classList.add('is-valid');
			el.parentNode.classList.remove('is-invalid');
		} else {
			el.parentNode.classList.add('is-invalid');
			el.parentNode.classList.remove('is-valid');
		}
	}

	// Select2
	$('.select2').select2();

	// Summernote
	$('.summernote').summernote({
		minHeight: 100,
		callbacks: {
			onChange: function(contents, $editable) {
				// fix https://github.com/summernote/summernote/issues/2631
				if ($(this).summernote('isEmpty') && contents != '') {
					$(this).summernote('code', '');
				}
			}
		}
	});

	for (const el of document.querySelectorAll('.tagin')) {
		tagin(el);
	}
});

App.autosize(document.querySelectorAll('textarea.autosize'));
App.autowidth();
App.inputRating();
// Data example
monthNames = ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez']
data1 = [150, 110, 90, 115, 125, 160, 160, 140, 100, 110, 120, 120]
data2 = [180, 140, 120, 135, 155, 170, 180, 150, 140, 150, 130, 130]
data3 = [100, 90, 60, 70, 100, 75, 90, 85, 90, 100, 95, 88]

// Chart options
const options = {
	maintainAspectRatio: false, // disable the maintain aspect ratio in options then it uses the available height
	tooltips: {
		mode: 'index',
		intersect: false, // Interactions configuration: https://www.chartjs.org/docs/latest/general/interactions/
	},
	elements: {
		rectangle: {
			borderWidth: 1 // bar border width
		},
		line: {
			borderWidth: 1 // label border width
		}
	},
	legend: {
		display: false // hide label
	}
}

/***************** Website Audience Metrics *****************/
new Chart('websiteAudienceMetrics',
	{
		type: 'bar',
		data: {
			labels: monthNames,
			datasets: [
				{
					backgroundColor: Chart.helpers.color(cyan).alpha(0.5).rgbString(),
					borderColor: cyan,
					data: data1
				},
				{
					backgroundColor: Chart.helpers.color(blue).alpha(0.5).rgbString(),
					borderColor: blue,
					data: data2
				}
			]
		},
		options: options
	});

/***************** Sessions By Channel *****************/
new Chart('sessionsByChannel',
	{
		type: 'doughnut',
		data: {
			labels: ['Organic Search', 'Email', 'Referrral', 'Social Media'],
			datasets: [
				{
					data: [25, 20, 30, 25],
					backgroundColor: [
						Chart.helpers.color(red).alpha(0.5).rgbString(),
						Chart.helpers.color(blue).alpha(0.5).rgbString(),
						Chart.helpers.color(cyan).alpha(0.5).rgbString(),
						Chart.helpers.color(orange).alpha(0.5).rgbString(),
					]
				}
			]
		},
		options: options
	});

/***************** Device Sessions *****************/
new Chart('deviceSessions',
	{
		type: 'line',
		data: {
			labels: monthNames,
			datasets: [
				{
					label: 'Mobile',
					backgroundColor: Chart.helpers.color(blue).alpha(0.1).rgbString(),
					borderColor: blue,
					tension: 0,
					pointRadius: 0,
					data: data2
				},
				{
					label: 'Desktop',
					backgroundColor: Chart.helpers.color(yellow).alpha(0.1).rgbString(),
					borderColor: yellow,
					tension: 0,
					pointRadius: 0,
					data: data1
				},
				{
					label: 'Other',
					backgroundColor: Chart.helpers.color(pink).alpha(0.1).rgbString(),
					borderColor: pink,
					tension: 0,
					pointRadius: 0,
					data: data3
				}
			]
		},
		options: options
	});

$(() => {
	/***************** Connections *****************/
	$('#connections').sparkline('html',
		{
			type: 'bar',
			barWidth: 8,
			height: 20,
			barColor: blue
		});

	/***************** Your Articles *****************/
	$('#yourArticles').sparkline('html',
		{
			type: 'bar',
			barWidth: 8,
			height: 20,
			barColor: red
		});

	/***************** Your Photos *****************/
	$('#yourPhotos').sparkline('html',
		{
			type: 'bar',
			barWidth: 8,
			height: 20,
			barColor: green
		});

	/***************** Your Photos *****************/
	$('#pageLikes').sparkline('html',
		{
			type: 'bar',
			barWidth: 8,
			height: 20,
			barColor: cyan
		});

	// Inline
	flatpickr('.datepicker-inline',
		{
			inline: true
		});

	// Basic
	flatpickr('.datepicker');

	// Datetime
	flatpickr('.datetimepicker',
		{
			enableTime: true
		});

	// Allow Input
	flatpickr('.datepicker-input',
		{
			allowInput: true,
			data
		});

	// External elements
	flatpickr('.datepicker-wrap',
		{
			allowInput: true,
			clickOpens: false,
			wrap: true
		});

	// Date Range
	flatpickr('.daterangepicker',
		{
			mode: 'range'
		});
	flatpickr('.daterangepicker-wrap',
		{
			allowInput: true,
			clickOpens: false,
			wrap: true,
			mode: 'range'
		});

	// Multiple Dates
	flatpickr('.datepicker-multiple',
		{
			mode: 'multiple'
		});
	flatpickr('.datepicker-multiple-wrap',
		{
			allowInput: true,
			clickOpens: false,
			wrap: true,
			mode: 'multiple'
		});

	// Month Picker
	flatpickr('.monthpicker',
		{
			plugins: [
				new monthSelectPlugin({
					shorthand: true,
					dateFormat: 'Y-m',
					altFormat: 'Y-m'
				})
			]
		});
	flatpickr('.monthpicker-wrap',
		{
			allowInput: true,
			clickOpens: false,
			wrap: true,
			plugins: [
				new monthSelectPlugin({
					shorthand: true,
					dateFormat: 'Y-m',
					altFormat: 'Y-m'
				})
			]
		});

	// Time Picker
	flatpickr('.timepicker',
		{
			enableTime: true,
			noCalendar: true,
			dateFormat: 'H:i',
			minuteIncrement: 1
		});
	flatpickr('.timepicker-wrap',
		{
			allowInput: true,
			enableTime: true,
			noCalendar: true,
			dateFormat: 'H:i',
			minuteIncrement: 1,
			clickOpens: false,
			wrap: true
		});

	// Clock Picker
	$('.clockpicker').clockpicker({
		autoclose: true
	});
});
