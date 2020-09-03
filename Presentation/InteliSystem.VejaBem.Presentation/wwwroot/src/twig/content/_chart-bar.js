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
          borderWidth: 1
        },
        rectangle: {
          borderWidth: 1
        }
      }
    }

    /***************** VERTICAL *****************/
    new Chart('bar-chart-vertical', {
      type: 'bar',
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

    /***************** HORIZONTAL *****************/
    new Chart('bar-chart-horizontal', {
      type: 'horizontalBar',
      data: {
        labels: monthNames,
        datasets: [{
          label: 'My dataset',
          backgroundColor: Chart.helpers.color(green).alpha(0.5).rgbString(),
          borderColor: green,
          data: data1
        }]
      },
      options: options
    })

    /***************** MULTI AXIS *****************/
    new Chart('bar-chart-multi', {
      type: 'bar',
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

    /***************** STACKED *****************/
    options.scales= {
      xAxes: [{
        stacked: true,
      }],
      yAxes: [{
        stacked: true
      }]
    }
    let chartStacked = new Chart('bar-chart-stacked', {
      type: 'bar',
      data: {
        labels: monthNames,
        datasets: [
          {
            label: '2018',
            backgroundColor: Chart.helpers.color(purple).alpha(0.5).rgbString(),
            borderColor: purple,
            data: data1
          },
          {
            label: '2019',
            backgroundColor: Chart.helpers.color(pink).alpha(0.5).rgbString(),
            borderColor: pink,
            data: data2
          }
        ]
      },
      options: options
    })