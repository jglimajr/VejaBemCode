/***************** CARD RELOAD *****************/
    document.getElementById('exampe-card-with-toolbar').addEventListener('card:reload', function () {
      var thisCard = this

      // YOUR ACTION HERE

      // do nothing for a second (this is only for demo)
      setTimeout(() => {
        App.stopCardLoader(thisCard) // when done, run this function
      }, 1000)
    })