// Data example
    monthNames = ['January', 'February', 'March', 'April', 'May', 'June', 'July']
    data1 = [33, 79, 85, 54, 64, 97, 79]
    data2 = [84, 100, 64, 18, 16, 94, 73]

    // Chart options
    const options = {
      maintainAspectRatio: false, // disable the maintain aspect ratio in options then it uses the available height
      tooltips: {
        mode: 'index',
        intersect: false, // Interactions configuration: https://www.chartjs.org/docs/latest/general/interactions/
      },
      elements: {
        line: {
          borderWidth: 1,
          fill: false
        }
      }
    }

    /***************** BASIC *****************/
    new Chart('line-chart-basic', {
      type: 'line',
      data: {
        labels: monthNames,
        datasets: [{
          label: 'My dataset',
          backgroundColor: Chart.helpers.color(blue).alpha(0.5).rgbString(),
          borderColor: blue,
          data: data1
        }]
      },
      options: options
    })

    /***************** STRAIGHT LINES *****************/
    new Chart('line-chart-straightlines', {
      type: 'line',
      data: {
        labels: monthNames,
        datasets: [{
          label: 'My dataset',
          backgroundColor: Chart.helpers.color(green).alpha(0.5).rgbString(),
          borderColor: green,
          tension: 0,
          data: data1
        }]
      },
      options: options
    })

    /***************** MULTI AXIS *****************/
    new Chart('line-chart-multi', {
      type: 'line',
      data: {
        labels: monthNames,
        datasets: [
          {
            label: '2018',
            backgroundColor: Chart.helpers.color(cyan).alpha(0.5).rgbString(),
            borderColor: cyan,
            data: data1
          },
          {
            label: '2019',
            backgroundColor: Chart.helpers.color(yellow).alpha(0.5).rgbString(),
            borderColor: yellow,
            data: data2
          }
        ]
      },
      options: options
    })

    /***************** FILL AREA *****************/
    new Chart('line-chart-fill', {
      type: 'line',
      data: {
        labels: monthNames,
        datasets: [{
          label: 'My dataset',
          backgroundColor: Chart.helpers.color(yellow).alpha(0.5).rgbString(),
          borderColor: yellow,
          tension: 0,
          fill: true,
          data: data1
        }]
      },
      options: options
    })

    /***************** DASH LINES *****************/
    new Chart('line-chart-dash', {
      type: 'line',
      data: {
        labels: monthNames,
        datasets: [{
          label: 'My dataset',
          backgroundColor: Chart.helpers.color(purple).alpha(0.5).rgbString(),
          borderColor: purple,
          borderDash: [5, 5],
          data: data1
        }]
      },
      options: options
    })

    /***************** POINT STYLE *****************/
    let chartPointStyle = new Chart('line-chart-point-style', {
      type: 'line',
      data: {
        labels: monthNames,
        datasets: [{
          label: 'My dataset',
          backgroundColor: Chart.helpers.color(pink).alpha(0.5).rgbString(),
          borderColor: pink,
          pointRadius: 10, // size
          pointHoverRadius: 15, // on hover size
          data: data1
        }]
      },
      options: options
    })
    chartPointStyle.options.elements.point.pointStyle = 'circle' // circle | cross | crossRot | dash | line | rect | rectRounded | rectRot | star | triangle
    chartPointStyle.update()

    // Change point style
    document.querySelector('#pointStyle').addEventListener('change', function () {
      chartPointStyle.options.elements.point.pointStyle = this.value
      chartPointStyle.update()
    })