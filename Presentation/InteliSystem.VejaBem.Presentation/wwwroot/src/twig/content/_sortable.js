// create from all .sortable classes
    document.querySelectorAll('.sortable').forEach(function (el) {
      const swap = el.classList.contains('swap')
      Sortable.create(el, {
        swap: swap,
        animation: 150,
        handle: '.sort-handle',
        filter: '.remove-handle',
        onFilter: function (evt) {
          evt.item.parentNode.removeChild(evt.item)
        }
      })
    })

    // Shared lists
    Sortable.create(document.getElementById('left'), {
      animation: 150,
      group: 'shared', // set both lists to same group
      handle: '.sort-handle'
    })
    Sortable.create(document.getElementById('right'), {
      animation: 150,
      group: 'shared',
      handle: '.sort-handle'
    })

    // Cloning
    Sortable.create(document.getElementById('left-cloneable'), {
      animation: 150,
      group: {
        name: 'cloning',
        pull: 'clone' // To clone: set pull to 'clone'
      },
      handle: '.sort-handle'
    })
    Sortable.create(document.getElementById('right-cloneable'), {
      animation: 150,
      group: {
        name: 'cloning',
        pull: 'clone'
      },
      handle: '.sort-handle'
    })