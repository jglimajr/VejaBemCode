const App = (() => {
  'use strict'

  // Debounced resize event (width only). [ref: https://paulbrowne.xyz/debouncing]
  function resize(a, b) {
    const c = [window.innerWidth]
    return window.addEventListener('resize', () => {
      const e = c.length
      c.push(window.innerWidth)
      if (c[e] !== c[e - 1]) {
        clearTimeout(b)
        b = setTimeout(a, 150)
      }
    }), a
  }

  // Bootstrap breakPoint checker
  function breakPoint(value) {
    let el, check, cls

    switch (value) {
      case 'xs': cls = 'd-none d-sm-block'; break
      case 'sm': cls = 'd-block d-sm-none d-md-block'; break
      case 'md': cls = 'd-block d-md-none d-lg-block'; break
      case 'lg': cls = 'd-block d-lg-none d-xl-block'; break
      case 'xl': cls = 'd-block d-xl-none'; break
      case 'smDown': cls = 'd-none d-md-block'; break
      case 'mdDown': cls = 'd-none d-lg-block'; break
      case 'lgDown': cls = 'd-none d-xl-block'; break
      case 'smUp': cls = 'd-block d-sm-none'; break
      case 'mdUp': cls = 'd-block d-md-none'; break
      case 'lgUp': cls = 'd-block d-lg-none'; break
    }

    el = document.createElement('div')
    el.setAttribute('class', cls)
    document.body.appendChild(el)
    check = el.offsetParent === null
    el.parentNode.removeChild(el)

    return check
  }

  // Shorthand for Bootstrap breakPoint checker
  function xs() { return breakPoint('xs') }
  function sm() { return breakPoint('sm') }
  function md() { return breakPoint('md') }
  function lg() { return breakPoint('lg') }
  function xl() { return breakPoint('xl') }
  function smDown() { return breakPoint('smDown') }
  function mdDown() { return breakPoint('mdDown') }
  function lgDown() { return breakPoint('lgDown') }
  function smUp() { return breakPoint('smUp') }
  function mdUp() { return breakPoint('mdUp') }
  function lgUp() { return breakPoint('lgUp') }

  // Nav Sub
  function navSub() {
    document.addEventListener('click', e => {
      if (e.target.closest('.nav-sub')) {
        if (e.target.closest('.dropdown-toggle')) {
          const nav = e.target.closest('.nav-sub')
          const el = e.target.closest('.dropdown-toggle')
          if (nav.dataset.accordion != 'false') {
            // close all dropdowns
            nav.querySelectorAll('.show').forEach(shown => el != shown && shown.classList.remove('show'))
          }
          el.classList.toggle('show')
          nav.dispatchEvent(new Event('navsub:update'))
          e.preventDefault()
        }
      }
    })
    for (const nav of document.querySelectorAll('.nav-sub')) {
      // open dropdown for sub has active
      nav.querySelectorAll('.active').forEach(el => !el.classList.contains('nav-link') && el.closest('.nav-item').querySelector('.nav-link').classList.add('active', 'show'))
    }
  }

  // Toggle sidebar collapse or expand
  function toggleSidebar() {
    document.addEventListener('click', e => {
      if (e.target.closest('[data-toggle="sidebar"]')) {
        lgUp() ? document.body.classList.toggle('sidebar-collapse') : document.body.classList.toggle('sidebar-expand')
        document.querySelector('.sidebar-body').scrollTop = 0
        e.preventDefault()
      }
    })

    void function () {
      // Insert sidebar backdrop
      document.body.insertAdjacentHTML('beforeend', '<div class="sidebar-backdrop" id="sidebarBackdrop" data-toggle="sidebar"></div>')

      // Remember sidebar scroll position
      const sidebar = document.querySelector('.sidebar')
      if (sidebar) {
        const sidebarBody = sidebar.querySelector('.sidebar-body')
        let bodyClass = document.body.classList
        let scrollPosition = 0
        let lock = false
        sidebarBody.addEventListener('scroll', function () {
          !lock && (scrollPosition = this.scrollTop) // save last scroll
        })
        document.addEventListener('click', e => {
          if (e.target.closest('[data-toggle="sidebar"]')) {
            if (!bodyClass.contains('sidebar-collapse') || bodyClass.contains('sidebar-expand')) {
              sidebarBody.scrollTop = scrollPosition // restore position on expanded
            }
          }
        })
        sidebar.addEventListener('mouseenter', () => {
          if (bodyClass.contains('sidebar-collapse') && lgUp()) {
            lock = false
            sidebarBody.scrollTop = scrollPosition // restore on hover
          }
        })
        sidebar.addEventListener('mouseleave', () => {
          if (bodyClass.contains('sidebar-collapse') && lgUp()) {
            lock = true
            sidebarBody.scrollTop = 0 // reset on unhover
          }
        })
      }
    }()
  }

  // Custom scrollbar for sidebar
  function sidebarBodyCustomScrollBar() {
    new SimpleBar(document.querySelector('.sidebar .sidebar-body'))
  }

  // Focus to modal content who has 'autofocus' attribute
  function autofocusModal() {
    $(document).on('shown.bs.modal', '.modal', function () {
      const autofocusEl = this.querySelector('[autofocus]')
      autofocusEl && autofocusEl.focus()
    })
  }

  // Show filename for bootstrap custom file input
  function customFileInput() {
    document.addEventListener('change', e => {
      if (e.target.closest('.custom-file-input')) {
        const el = e.target.closest('.custom-file-input')
        const chooseText = el.dataset.choose ? el.dataset.choose : el.nextElementSibling.innerText
        !el.dataset.choose && (el.dataset.choose = chooseText)
        const fileLength = el.files.length
        let filename = fileLength ? el.files[0].name : chooseText
        filename = fileLength > 1 ? fileLength + ' files' : filename // if more than one file, show '{amount} files'
        el.parentElement.querySelector('label').textContent = filename
      }
    })
  }

  // Functional card toolbar
  function cardToolbar() {
    document.addEventListener('click', e => {
      if (e.target.closest('[data-action]')) {
        const el = e.target.closest('[data-action]')
        const card = el.closest('.card')
        switch (el.dataset.action) {
          case 'fullscreen':
            card.classList.toggle('card-fullscreen')
            if (card.classList.contains('card-fullscreen')) {
              el.innerHTML = '<i class="material-icons">fullscreen_exit</i>'
              document.body.style.overflow = 'hidden'
            } else {
              el.innerHTML = '<i class="material-icons">fullscreen</i>'
              document.body.removeAttribute('style')
            }
            break;
          case 'close':
            card.remove()
            break;
          case 'reload':
            card.insertAdjacentHTML('afterbegin', '<div class="card-loader-overlay"><div class="spinner-border text-white" role="status"></div></div>')
            card.dispatchEvent(new Event('card:reload'))
            break;
          case 'collapse':
            const collapsingTransition = parseFloat(getComputedStyle(document.querySelector('.collapsing'))['transitionDuration']) * 1000
            setTimeout(() => {
              if (document.querySelector(el.dataset.target).matches('.collapse.show')) {
                el.innerHTML = '<i class="material-icons">remove</i>'
              } else {
                el.innerHTML = '<i class="material-icons">add</i>'
              }
            }, collapsingTransition);
            break;
        }
      }
    })
  }

  // Nav section
  function navSection() {
    if (document.querySelector('#navSection')) {
      $('body').scrollspy('dispose')
      $('body').scrollspy({
        target: '#navSection',
        offset: 140,
      })
    }
    document.addEventListener('click', e => {
      if (e.target.closest('#navSection')) {
        const target = document.querySelector(e.target.getAttribute('href'))
        const y = target.getBoundingClientRect().top + window.pageYOffset - ((document.body.dataset.offset || 140) - 1)
        window.scrollTo({ top: y, behavior: 'smooth' })
        e.preventDefault()
      }
    })
  }

  // Set accordion active card
  function accordionActive() {
    $('.collapse.show[data-parent]').closest('.card').addClass('active')
    $(document)
      .on('show.bs.collapse', '.collapse[data-parent]', function () {
        $(this).closest('.card').addClass('active')
      })
      .on('hide.bs.collapse', '.collapse[data-parent]', function () {
        $(this).closest('.card').removeClass('active')
      })
  }

  // Dropdown hover
  function dropdownHover() {
    document.addEventListener('mouseover', e => {
      if (lgUp()) {
        if (e.target.closest('.dropdown-hover')) {
          $('.dropdown-hover').removeClass('show')
          e.target.closest('.dropdown-hover').classList.add('show')
        } else {
          $('.dropdown-hover').removeClass('show')
        }
      }
    })
  }

  // Table with check all & bulk action
  function checkAll() {
    if (document.querySelectorAll('.has-checkAll').length) {
      const activeTr= 'table-active'
      for (const el of document.querySelectorAll('.has-checkAll')) {
        const thCheckbox = el.querySelector('th input[type="checkbox"]')
        const tdCheckbox = el.querySelectorAll('tr > td:first-child input[type="checkbox"]')
        const bulkTarget = el.dataset.bulkTarget
        let activeClass = el.dataset.checkedClass
        activeClass = activeClass ? activeClass : activeTr
        thCheckbox.addEventListener('click', function () {
          for (const cb of tdCheckbox) {
            cb.checked = this.checked
            cb.checked ? cb.closest('tr').classList.add(activeClass) : cb.closest('tr').classList.remove(activeClass)
          }
          bulkTarget && toggleBulkDropdown(bulkTarget, tdCheckbox)
        })
        for (const cb of tdCheckbox) {
          cb.addEventListener('click', function () {
            this.checked ? this.closest('tr').classList.add(activeClass) : this.closest('tr').classList.remove(activeClass)
            bulkTarget && toggleBulkDropdown(bulkTarget, tdCheckbox)
          })
        }
      }
      function toggleBulkDropdown(el, tdCheckbox) {
        let count = 0
        const bulk_dropdown = document.querySelector(el)
        tdCheckbox.forEach(cb => cb.checked && count++)
        bulk_dropdown.querySelector('.checked-counter') && (bulk_dropdown.querySelector('.checked-counter').textContent = count)
        count != 0 ? bulk_dropdown.removeAttribute('hidden') : bulk_dropdown.setAttribute('hidden', '')
      }
    }
  }

  // Background cover
  function backgroundCover() {
    document.querySelectorAll('[data-cover]').forEach(el => el.style.backgroundImage = `url(${el.dataset.cover})`)
  }

  // Toggle inner sidebar
  function innerToggleSidebar() {
    document.addEventListener('click', e => {
      if (e.target.closest('[data-toggle="inner-sidebar"]')) {
        const el = e.target.closest('[data-toggle="inner-sidebar"]')
        const body = document.body
        body.classList.toggle('inner-expand')
        if (body.classList.contains('inner-expand')) {
          el.innerHTML = '<i class="material-icons">close</i>'
        } else {
          el.innerHTML = '<i class="material-icons">arrow_forward_ios</i>'
        }
        e.preventDefault()
      }
    })
  }

  // Scrolling navbar
  function scrollNavbar() {
    if (document.querySelector('.main-navbar')) {
      const navbar = document.querySelector('.main-navbar .navbar-collapse')
      setTimeout(() => {
        resize(() => {
          if (lgUp()) {
            for (const el of document.querySelectorAll('[data-scroll]')) {
              if (navbar.querySelector('.navbar-nav').getBoundingClientRect().width > navbar.getBoundingClientRect().width) {
                el.removeAttribute('hidden')
              } else {
                el.setAttribute('hidden', '')
              }
            }
          }
        })()
      }, 500)
      for (const el of document.querySelectorAll('[data-scroll]')) {
        el.addEventListener('click', e => {
          let width = navbar.getBoundingClientRect().width / 2
          switch (el.dataset.scroll) {
            case 'left':
              navbar.scrollLeft -= width
              break;
            case 'right':
              navbar.scrollLeft += width
              break;
          }
          e.preventDefault()
        })
      }

      // fix dropdown-menu position
      $('.main-navbar .dropdown').on('show.bs.dropdown', function () {
        let margin = document.querySelector('.main-navbar .navbar-collapse').scrollLeft
        this.querySelector('.dropdown-menu').style.marginLeft = -margin + 'px'
      })
    }
  }

  // Feather icon
  function featherIcon() {
    feather.replace()
    const observer = new MutationObserver(() => feather.replace())
    observer.observe(document.querySelector('.main'), { childList: true, subtree: true, })
    observer.observe(document.querySelector('.sidebar'), { childList: true, subtree: true, })
  }

  // Togle Todo item done
  function todo() {
    document.addEventListener('click', e => {
      if (e.target.closest('[data-toggle="todo-item"]')) {
        const el = e.target.closest('[data-toggle="todo-item"]')
        const ti = el.closest('.todo-item')
        el.checked ? ti.classList.add('done') : ti.classList.remove('done')
      }
    })
  }

  // Fix flatpickr year scroll
  function fixFlatpickr() {
    document.addEventListener('wheel', function () {
      if (document.activeElement.classList.contains('cur-year')) {
        document.activeElement.blur()
      }
    })
  }

  // Add summernote focus class onFocus
  function summernoteFocus() {
    $(document).on('summernote.focus', '.summernote', function () {
      $(this).next().addClass('focus')
    }).on('summernote.blur', '.summernote', function () {
      $(this).next().removeClass('focus')
    })
  }

  // Toast
  function toast(option) {
    const animation = option.animation !== undefined ? option.animation : 'true'
    const autohide = option.autohide !== undefined ? option.autohide : 'true'
    const position = option.position !== undefined ? option.position : 'top-right'
    const wrapper = '.toast-wrapper.' + position
    const delay = option.delay !== undefined ? option.delay : 2000
    const id = 'toast' + Date.now()

    // Icon
    const iconSuccess = '<svg class="mr-2 text-success" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" width="21" height="21"><path d="M0 0h24v24H0z" fill="none"/><path d="M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm-2 15l-5-5 1.41-1.41L10 14.17l7.59-7.59L19 8l-9 9z"/></svg>'
    const iconWarning = '<svg class="mr-2 text-warning" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" width="21" height="21"><path d="M0 0h24v24H0z" fill="none"/><path d="M1 21h22L12 2 1 21zm12-3h-2v-2h2v2zm0-4h-2v-4h2v4z"/></svg>'
    const iconError = '<svg class="mr-2 text-danger" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" width="21" height="21"><path d="M0 0h24v24H0z" fill="none"/><path d="M0 0h24v24H0z" fill="none"/><path d="M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm1 15h-2v-2h2v2zm0-4h-2V7h2v6z"/></svg>'
    const iconInfo = '<svg class="mr-2" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" width="21" height="21"><path d="M0 0h24v24H0z" fill="none"></path><path d="M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm1 15h-2v-6h2v6zm0-8h-2V7h2v2z"></path></svg>'
    let icon = ''
    switch (option.icon) {
      case 'success': icon = iconSuccess; break;
      case 'warning': icon = iconWarning; break;
      case 'error': icon = iconError; break;
      default: icon = iconInfo; break;
    }

    const toast = `
      <div class="toast" role="alert" aria-live="assertive" aria-atomic="true" id="${id}" data-autohide="${autohide}" data-animation="${animation}" data-delay="${delay}">
        <div class="toast-header">
          ${icon}
          <strong>${option.title}</strong>
          <button type="button" class="close ml-auto" data-dismiss="toast" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="toast-body">${option.text}</div>
      </div>
    `

    if (!document.querySelector(wrapper)) {
      document.body.insertAdjacentHTML('beforeend', `<div class="toast-wrapper ${position}"></div>`)
    }
    document.querySelector(wrapper).insertAdjacentHTML('beforeend', toast)
    $('#' + id).toast('show')
    $('#' + id).on('hidden.bs.toast', function () {
      this.remove()
      if (document.querySelectorAll(wrapper + ' .toast').length < 1) {
        document.querySelector(wrapper).remove()
      }
    })
  }

  // Auto width input
  function autowidth() {
    if (document.querySelectorAll('.autowidth-hidden').length) {
      document.querySelectorAll('.autowidth-hidden').forEach(el => el.remove())
    }
    function setWidth(el, fakeEl) {
      const string = el.value || el.getAttribute('placeholder') || ''
      fakeEl.innerHTML = string.replace(/ /g, '&nbsp;')
      el.style.setProperty('width', Math.ceil(window.getComputedStyle(fakeEl).width.replace('px', '')) + 1 + 'px', 'important')
    }
    for (const el of document.querySelectorAll('.autowidth')) {
      const fakeEl = document.createElement('div')
      fakeEl.classList.add('autowidth-hidden')
      const styles = window.getComputedStyle(el)
      fakeEl.style.fontFamily = styles.fontFamily
      fakeEl.style.fontSize = styles.fontSize
      fakeEl.style.fontStyle = styles.fontStyle
      fakeEl.style.fontWeight = styles.fontWeight
      fakeEl.style.letterSpacing = styles.letterSpacing
      fakeEl.style.textTransform = styles.textTransform
      fakeEl.style.borderLeftWidth = styles.borderLeftWidth
      fakeEl.style.borderRightWidth = styles.borderRightWidth
      fakeEl.style.paddingLeft = styles.paddingLeft
      fakeEl.style.paddingRight = styles.paddingRight
      document.body.appendChild(fakeEl)
      setWidth(el, fakeEl)
      el.addEventListener('input', () => setWidth(el, fakeEl))
    }
  }

  // Input rating
  function inputRating() {
    if (document.querySelectorAll('.rating-container').length) {
      document.querySelectorAll('.rating-container').forEach(el => el.remove())
    }
    document.addEventListener('click', e => {
      if (e.target.closest('.rating-input')) {
        const input = e.target.closest('.rating-input')
        const container = input.closest('.rating-container')
        container.querySelectorAll('.active').forEach(el => el.classList.remove('active'))
        input.parentNode.classList.add('active')
        container.querySelectorAll('.active ~ label').forEach(el => el.classList.add('active'))
        const originalInput = container.previousSibling
        if (originalInput.value !== input.value) {
          originalInput.value = input.value
          originalInput.dispatchEvent(new Event('change'))
        }
      }
    })
    for (const input of document.querySelectorAll('.input-rating')) {
      input.setAttribute('hidden', true)
      const icon = '<svg fill="currentColor" xmlns="http://www.w3.org/2000/svg" height="24" viewBox="0 0 24 24" width="24"><path d="M0 0h24v24H0z" fill="none"/><path d="M0 0h24v24H0z" fill="none"/><path d="M12 17.27L18.18 21l-1.64-7.03L22 9.24l-7.19-.61L12 2 9.19 8.63 2 9.24l5.46 4.73L5.82 21z"/></svg>'
      const name = 'rating' + Date.now()
      const container = `
      <div class="rating-container">
        <label><input class="rating-input" type="radio" name="${name}" value="5">${icon}</label>
        <label><input class="rating-input" type="radio" name="${name}" value="4">${icon}</label>
        <label><input class="rating-input" type="radio" name="${name}" value="3">${icon}</label>
        <label><input class="rating-input" type="radio" name="${name}" value="2">${icon}</label>
        <label><input class="rating-input" type="radio" name="${name}" value="1">${icon}</label>
      </div>`
      input.insertAdjacentHTML('afterend', container)
      if (input.value > 0 && input.value < 6) {
        input.nextElementSibling.querySelector(`input[value="${input.value}"]`).click()
      }
    }
  }

  // Toggle password visibility
  function togglePassword() {
    document.addEventListener('click', e => {
      if (e.target.closest('[data-toggle="password"]')) {
        const input = e.target.closest('[data-toggle="password"]').parentNode.querySelector('input')
        input.type = input.type === 'password' ? 'text' : 'password'
      }
    })
  }

  return {
    resize: callback => resize(callback),
    xs: () => xs(),
    sm: () => sm(),
    md: () => md(),
    lg: () => lg(),
    xl: () => xl(),
    smDown: () => smDown(),
    mdDown: () => mdDown(),
    lgDown: () => lgDown(),
    smUp: () => smUp(),
    mdUp: () => mdUp(),
    lgUp: () => lgUp(),
    navSub: () => navSub(),
    toggleSidebar: () => toggleSidebar(),
    sidebarBodyCustomScrollBar: () => sidebarBodyCustomScrollBar(),
    autofocusModal: () => autofocusModal(),
    color: variant => getComputedStyle(document.body).getPropertyValue('--' + variant).trim(),
    customFileInput: () => customFileInput(),
    cardToolbar: () => cardToolbar(),
    stopCardLoader: card => {
      let overlay = card.querySelector('.card-loader-overlay')
      overlay.parentNode.removeChild(overlay)
    },
    navSection: () => navSection(),
    accordionActive: () => accordionActive(),
    dropdownHover: () => dropdownHover(),
    checkAll: () => checkAll(),
    backgroundCover: () => backgroundCover(),
    innerToggleSidebar: () => innerToggleSidebar(),
    scrollNavbar: () => scrollNavbar(),
    featherIcon: () => featherIcon(),
    todo: () => todo(),
    fixFlatpickr: () => fixFlatpickr(),
    summernoteFocus: () => summernoteFocus(),
    toast: option => toast(option),
    autowidth: () => autowidth(),
    inputRating: () => inputRating(),
    togglePassword: () => togglePassword(),
  }
})()

$(() => {
  $('[data-toggle="popover"]').popover()
  $('[data-toggle="tooltip"]').tooltip()
})

App.navSub()
App.toggleSidebar()
App.sidebarBodyCustomScrollBar()
App.autofocusModal()
App.customFileInput()
App.cardToolbar()
App.navSection()
App.accordionActive()
App.dropdownHover()
App.checkAll()
App.backgroundCover()
App.innerToggleSidebar()
App.scrollNavbar()
App.featherIcon()
App.todo()
App.fixFlatpickr()
App.summernoteFocus()
App.togglePassword()

const observer = new MutationObserver(() => {
  App.backgroundCover()
  App.navSection()
  App.accordionActive()
  $('[data-toggle="popover"]').popover()
  $('[data-toggle="tooltip"]').tooltip()
})
observer.observe(document.querySelector('.main'), { childList: true, subtree: true, })
observer.observe(document.querySelector('.sidebar'), { childList: true, subtree: true, })

// Sample colors
const blue   = App.color('blue')
const indigo = App.color('indigo')
const purple = App.color('purple')
const pink   = App.color('pink')
const red    = App.color('red')
const orange = App.color('orange')
const yellow = App.color('yellow')
const green  = App.color('green')
const teal   = App.color('teal')
const cyan   = App.color('cyan')
const gray   = App.color('gray')
const lime   = '#cddc39'

// This is for development, attach breakpoint to document title
/* App.resize(() => {
  if (App.xs()) { document.title = 'xs' }
  if (App.sm()) { document.title = 'sm' }
  if (App.md()) { document.title = 'md' }
  if (App.lg()) { document.title = 'lg' }
  if (App.xl()) { document.title = 'xl' }
})() */
