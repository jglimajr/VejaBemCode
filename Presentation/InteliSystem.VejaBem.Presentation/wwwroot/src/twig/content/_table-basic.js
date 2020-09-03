// Change table color style
    for (const color of document.querySelectorAll('input[name="table-color"]')) {
      color.addEventListener('change', function () {
        document.querySelector('#table-color').className = 'table table-' + color.value
      })
    }