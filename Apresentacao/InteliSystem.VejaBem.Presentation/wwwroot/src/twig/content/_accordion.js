// Change accordion active style
    for (const color of document.querySelectorAll('input[name="accordion-active-color"]')) {
      color.addEventListener('change', function () {
        document.querySelector('#accordion-unstacked-active-style').className = 'accordion-unstacked accordion-active-' + color.value
      })
    }
    // Change accordion active style
    for (const color of document.querySelectorAll('input[name="accordion-bg-color"]')) {
      color.addEventListener('change', function () {
        document.querySelector('#accordion-unstacked-active-bg').className = 'accordion-unstacked accordion-bg-' + color.value
      })
    }