// Collect photoswipe items
    const parseItem = container => {
      let items = []
      for (const el of container.querySelectorAll('.open-ps')) {
        const size = el.dataset.size.split('x')
        items.push({
          src: el.dataset.target,
          w: parseInt(size[0], 10),
          h: parseInt(size[1], 10),
        })
      }
      return items
    }

    // Photoswipe config
    const openGallery = function (activeIndex, items) {
      activeIndex = typeof activeIndex !== 'undefined' ? activeIndex - 1 : 0
      const options = {
        index: activeIndex,
        hideAnimationDuration: 0,
        showAnimationDuration: 0,
        history: false
      }
      const gallery = new PhotoSwipe(document.querySelector('.pswp'), PhotoSwipeUI_Default, items, options)
      gallery.init()
    }

    // Gallery
    const exampleGallery = document.querySelector('#example-gallery')
    const items = parseItem(exampleGallery)
    for (const el of exampleGallery.querySelectorAll('.open-ps')) {
      el.addEventListener('click', function () {
        openGallery(this.dataset.index, items)
      })
    }