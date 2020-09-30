// Make timeline left on xs
    const exampleTimeline = document.querySelector('#example-timeline')
    App.resize(function () {
      if (App.xs()) {
        exampleTimeline.classList.add('timeline-left')
        for (const el of exampleTimeline.querySelectorAll('.bs-popover-left')) {
          el.classList.replace('bs-popover-left', 'bs-popover-right')
          el.classList.add('replaced') // add a temporary class, so that it can be returned to the previous class
        }
      } else {
        exampleTimeline.classList.remove('timeline-left')
        for (const el of exampleTimeline.querySelectorAll('.replaced')) {
          el.classList.replace('bs-popover-right', 'bs-popover-left')
          el.classList.remove('replaced')
        }
      }
    })()