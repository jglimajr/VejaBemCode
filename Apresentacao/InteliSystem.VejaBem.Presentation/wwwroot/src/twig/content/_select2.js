for (const el of document.querySelectorAll('.select2')) {
      if (el.dataset.select2Search === 'true' && el.dataset.select2Content !== 'true') {
        $(el).select2()
      } else if (el.dataset.select2Search === 'true' && el.dataset.select2Content === 'true') {
        $(el).select2({
          templateResult: state => state.id ? $(state.element.dataset.content) : state.text,
          templateSelection: state => state.id ? $(state.element.dataset.content) : state.text
        })
      } else if (el.dataset.select2Search !== 'true' && el.dataset.select2Content === 'true') {
        $(el).select2({
          minimumResultsForSearch: 'Infinity', // hide search
          templateResult: state => state.id ? $(state.element.dataset.content) : state.text,
          templateSelection: state => state.id ? $(state.element.dataset.content) : state.text
        })
      } else {
        $(el).select2({
          minimumResultsForSearch: 'Infinity', // hide search
        })
      }
    }
