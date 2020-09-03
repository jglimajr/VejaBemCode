// Inline
      flatpickr('.datepicker-inline', {
        inline: true,
      })

      // Basic
      flatpickr('.datepicker')

      // Datetime
      flatpickr('.datetimepicker', {
        enableTime: true
      })

      // Allow Input
      flatpickr('.datepicker-input', {
        allowInput: true
      })

      // External elements
      flatpickr('.datepicker-wrap', {
        allowInput: true,
        clickOpens: false,
        wrap: true,
      })

      // Date Range
      flatpickr('.daterangepicker', {
        mode: 'range'
      })
      flatpickr('.daterangepicker-wrap', {
        allowInput: true,
        clickOpens: false,
        wrap: true,
        mode: 'range'
      })

      // Multiple Dates
      flatpickr('.datepicker-multiple', {
        mode: 'multiple'
      })
      flatpickr('.datepicker-multiple-wrap', {
        allowInput: true,
        clickOpens: false,
        wrap: true,
        mode: 'multiple'
      })

      // Month Picker
      flatpickr('.monthpicker', {
        plugins: [
          new monthSelectPlugin({
            shorthand: true,
            dateFormat: 'Y-m',
            altFormat: 'Y-m',
          })
        ]
      })
      flatpickr('.monthpicker-wrap', {
        allowInput: true,
        clickOpens: false,
        wrap: true,
        plugins: [
          new monthSelectPlugin({
            shorthand: true,
            dateFormat: 'Y-m',
            altFormat: 'Y-m',
          })
        ]
      })

      // Time Picker
      flatpickr('.timepicker', {
        enableTime: true,
        noCalendar: true,
        dateFormat: 'H:i',
        minuteIncrement: 1,
      })
      flatpickr('.timepicker-wrap', {
        allowInput: true,
        enableTime: true,
        noCalendar: true,
        dateFormat: 'H:i',
        minuteIncrement: 1,
        clickOpens: false,
        wrap: true,
      })

      // Clock Picker
      $('.clockpicker').clockpicker({ autoclose: true })
