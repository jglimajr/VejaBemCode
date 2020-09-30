// Example starter for disabling form submissions if there are invalid fields
      $('.needs-validation').on('submit', function (e) {
        if (this.checkValidity() === false) {
          e.preventDefault()
          e.stopPropagation()
        }
        this.classList.add('was-validated')
      })

      // Bootstrap select
      $('.bs-select').selectpicker({ style: 'btn' })
      function toggleClear(select, el) {
        el.style.display = select.value == '' ? 'none' : 'inline'
        if (select.value == '') {
          select.parentNode.querySelector('.filter-option').classList.remove('mr-4')
        } else {
          select.parentNode.querySelector('.filter-option').classList.add('mr-4')
        }
      }
      for (const el of document.querySelectorAll('select.bs-select, select.bs-select-sm, select.bs-select-lg')) {
        const clearEl = el.parentNode.nextElementSibling
        if (clearEl && clearEl.classList.contains('bs-select-clear')) {
          toggleClear(el, clearEl)
          el.addEventListener('change', function () {
            toggleClear(this, clearEl)
          })
        }
      }
      for (const el of document.querySelectorAll('.bs-select-clear')) {
        el.addEventListener('click', function () {
          const select = this.previousElementSibling.querySelector('select')
          $(select).selectpicker('val', '')
          select.dispatchEvent(new Event('change'))
        })
      }
      $('.bootstrap-select').on('show.bs.select', function () {
          this.querySelector('.dropdown-toggle').classList.add('focus')
      }).on('hide.bs.select', function () {
          this.querySelector('.dropdown-toggle').classList.remove('focus')
      })
      for (const el of document.querySelectorAll('select.bs-select')) {
        toggleValidityClass(el)
        el.addEventListener('change', () => toggleValidityClass(el))
      }
      function toggleValidityClass(el) {
        if (el.validity.valid) {
          el.parentNode.classList.add('is-valid')
          el.parentNode.classList.remove('is-invalid')
        } else {
          el.parentNode.classList.add('is-invalid')
          el.parentNode.classList.remove('is-valid')
        }
      }

      // Select2
      $('.select2').select2()

      // Summernote
      $('.summernote').summernote({
        minHeight: 100,
        callbacks: {
          onChange: function(contents, $editable) {
            // fix https://github.com/summernote/summernote/issues/2631
            if ($(this).summernote('isEmpty') && contents != '') {
              $(this).summernote('code', '')
            }
          }
        }
      })

      for (const el of document.querySelectorAll('.tagin')) {
        tagin(el)
      }
