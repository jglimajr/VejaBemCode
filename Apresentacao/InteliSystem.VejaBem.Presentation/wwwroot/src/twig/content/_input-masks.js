Inputmask.extendAliases({
      decimal: {
        alias: 'numeric',
        digits: 2,
        autoGroup: true,
        groupSeparator: ',',
      }
    })
    Inputmask().mask(document.querySelectorAll('.inputmask'))