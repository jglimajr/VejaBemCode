// Basic example
    noUiSlider.create(document.getElementById('slider1'), {
      start: 50,
      range: {
        min: 0,
        max: 100
      },
      tooltips: true
    })

    // Range
    noUiSlider.create(document.getElementById('slider2'), {
      start: [25, 75],
      range: {
        min: 0,
        max: 100
      },
      tooltips: true
    })

    // Connect 'lower'
    noUiSlider.create(document.getElementById('slider3'), {
      connect: 'lower',
      start: 25,
      range: {
        min: 0,
        max: 100
      },
      tooltips: true
    })

    // Connect 'upper'
    noUiSlider.create(document.getElementById('slider4'), {
      connect: 'upper',
      start: 75,
      range: {
        min: 0,
        max: 100
      },
      tooltips: true
    })

    // Connect 'true' sets the bars between the handles, but not between the handles and the sliders edges
    noUiSlider.create(document.getElementById('slider5'), {
      connect: true,
      start: [25, 75],
      range: {
        min: 0,
        max: 100
      },
      tooltips: true
    })

    // Step
    noUiSlider.create(document.getElementById('slider6'), {
      connect: 'lower',
      step: 5,
      start: 25,
      range: {
        min: 0,
        max: 100
      },
      tooltips: true
    })

    // Orientation
    noUiSlider.create(document.getElementById('slider7'), {
      orientation: 'vertical',
      connect: 'lower',
      start: 25,
      range: {
        min: 0,
        max: 100
      },
      tooltips: true
    })

    // Direction
    noUiSlider.create(document.getElementById('slider8'), {
      direction: 'rtl',
      connect: 'lower',
      start: 25,
      range: {
        min: 0,
        max: 100
      },
      tooltips: true
    })

    // Direction
    noUiSlider.create(document.getElementById('slider9'), {
      direction: 'rtl',
      orientation: 'vertical',
      connect: 'lower',
      start: 25,
      range: {
        min: 0,
        max: 100
      },
      tooltips: true
    })

    // Disable tooltip
    noUiSlider.create(document.getElementById('slider10'), {
      connect: 'lower',
      start: 25,
      range: {
        min: 0,
        max: 100
      },
      tooltips: false
    })

    // Color variations 'lower'
    let start = 20
    for (const el of document.querySelectorAll('.slider-variations')) {
      noUiSlider.create(el, {
        connect: 'lower',
        start: start,
        range: {
          min: 0,
          max: 100
        },
        tooltips: true
      })
      start = start + 10
    }
