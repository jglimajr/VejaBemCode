/***************** LINE CHARTS *****************/
      $('#line1').sparkline('html', {
        width: '125',
        height: 50,
        lineColor: yellow,
        fillColor: false
      })
      $('#line2').sparkline('html', {
        width: '125',
        height: 50,
        lineColor: cyan,
        fillColor: false
      })

      /***************** AREA CHARTS *****************/
      $('#area1').sparkline('html', {
        width: '125',
        height: 50,
        lineColor: yellow,
        fillColor: '#ffeab8'
      })
      $('#area2').sparkline('html', {
        width: '125',
        height: 50,
        lineColor: cyan,
        fillColor: '#bee5eb'
      })

      /***************** BAR CHARTS *****************/
      $('#bar1').sparkline('html', {
        type: 'bar',
        barWidth: 8,
        height: 50,
        barColor: yellow
      })
      $('#bar2').sparkline('html', {
        type: 'bar',
        barWidth: 8,
        height: 50,
        barColor: cyan
      })

      /***************** STACKED BAR CHARTS *****************/
      $('#stackedBar1').sparkline('html', {
        type: 'bar',
        barWidth: 8,
        height: 50,
        barColor: '#ffeab8'
      })
      $('#stackedBar1').sparkline([4,5,6,7,4,5,8,7,6,6,4,7,6,4,7], {
        composite: true,
        type: 'bar',
        barWidth: 8,
        height: 50,
        barColor: yellow
      })
      $('#stackedBar2').sparkline('html', {
        type: 'bar',
        barWidth: 8,
        height: 50,
        barColor: '#bee5eb'
      })
      $('#stackedBar2').sparkline([4,5,6,7,4,5,8,7,6,6,4,7,6,4,7], {
        composite: true,
        type: 'bar',
        barWidth: 8,
        height: 50,
        barColor: cyan
      })

      /***************** PIE CHARTS *****************/
      $('#pie1').sparkline('html', {
        type: 'pie',
        height: 70,
        sliceColors: [blue, green, red, yellow]
      })

      $('#pie2').sparkline('html', {
        type: 'pie',
        height: 70,
        sliceColors: [blue, green, red, yellow, purple, orange, lime, pink]
      })

      /***************** INLINE CHARTS *****************/
      $('#inline1').sparkline('html', {
        width: '50',
        height: 15,
        lineColor: yellow,
        fillColor: false
      })
      $('#inline2').sparkline('html', {
        width: '75',
        height: 15,
        lineColor: cyan,
        fillColor: '#bee5eb'
      })
      $('#inline3').sparkline('html', {
        type: 'bar',
        barWidth: 8,
        height: 15,
        barColor: red
      })