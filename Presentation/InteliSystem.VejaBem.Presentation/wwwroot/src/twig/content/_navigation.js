// toggle pills
    document.querySelector('#pills').addEventListener('change', function () {
      const navs = document.querySelectorAll('#content .nav:not(.nav-tabs-simple)')
      if (this.checked) {
        for (const el of navs) {
          el.classList.add('nav-pills')
        }
        document.querySelector('#content .nav-tabs').classList.add('nav-tabs_')
        document.querySelector('#content .nav-tabs').classList.remove('nav-tabs')
      } else {
        for (const el of navs) {
          el.classList.remove('nav-pills')
        }
        document.querySelector('#content .nav-tabs_').classList.add('nav-tabs')
        document.querySelector('#content .nav-tabs_').classList.remove('nav-tabs_')
      }
    })

    // toggle faded
    document.querySelector('#faded').addEventListener('change', function () {
      const navLinks = document.querySelectorAll('#content .nav-link')
      if (this.checked) {
        for (const el of navLinks) {
          if (!el.closest('.navbar-nav')) {
            el.classList.add('nav-link-faded')
          }
        }
      } else {
        for (const el of navLinks) {
          if (!el.closest('.navbar-nav')) {
            el.classList.remove('nav-link-faded')
          }
        }
      }
    })