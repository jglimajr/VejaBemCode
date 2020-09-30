// Data example
    ability = ['PAS', 'SHT', 'PHY', 'DEF', 'SPD', 'DRI']
    data1   = [ 86, 86, 63, 48, 89, 96 ]
    messi   = [ 88, 95, 70, 45, 86, 95 ]
    ronaldo = [ 83, 91, 86, 49, 88, 89 ]

    // Fix tooltip not shown: https://github.com/chartjs/Chart.js/issues/6188
    tooltipCallbackLabel = {
      label: (tooltipItem, data) => {
        return data.datasets[tooltipItem.datasetIndex].label + ' : ' + data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index]
      }
    }

    // Chart options
    const options = {
      maintainAspectRatio: false, // disable the maintain aspect ratio in options then it uses the available height
      tooltips: {
        // mode: 'index',
        // intersect: false, // Interactions configuration: https://www.chartjs.org/docs/latest/general/interactions/
        callbacks: tooltipCallbackLabel
      },
      elements: {
        line: {
          borderWidth: 1
        }
      }
    }

    /***************** BASIC *****************/
    new Chart('radar-basic', {
      type: 'radar',
      data: {
        labels: ability,
        datasets: [{
          label: 'Ability',
          fill: false,
          backgroundColor: Chart.helpers.color(blue).alpha(0.5).rgbString(),
          borderColor: blue,
          data: data1
        }]
      },
      options: options
    })

    /***************** SMOOTH *****************/
    new Chart('radar-chart-smooth', {
      type: 'radar',
      data: {
        labels: ability,
        datasets: [{
          label: 'Ability',
          fill: false,
          backgroundColor: Chart.helpers.color(green).alpha(0.5).rgbString(),
          borderColor: green,
          tension: 0.4, // add this option to make it 'smooth'
          data: data1
        }]
      },
      options: options
    })

    /***************** MULTI AXIS *****************/
    let chartMulti = new Chart('radar-chart-multi', {
      type: 'radar',
      data: {
        labels: ability,
        datasets: [
          {
            label: 'L. Messi',
            fill: false,
            backgroundColor: Chart.helpers.color(cyan).alpha(0.5).rgbString(),
            borderColor: cyan,
            data: messi
          },
          {
            label: 'C. Ronaldo',
            fill: false,
            backgroundColor: Chart.helpers.color(red).alpha(0.5).rgbString(),
            borderColor: red,
            data: ronaldo
          }
        ]
      },
      options: options
    })
    chartMulti.options.tooltips.mode = 'index'
    chartMulti.update()

    /***************** FILLED *****************/
    let chartFilled = new Chart('radar-chart-filled', {
      type: 'radar',
      data: {
        labels: ability,
        datasets: [
          {
            label: 'L. Messi',
            backgroundColor: Chart.helpers.color(cyan).alpha(0.5).rgbString(),
            borderColor: cyan,
            data: messi
          },
          {
            label: 'C. Ronaldo',
            backgroundColor: Chart.helpers.color(red).alpha(0.5).rgbString(),
            borderColor: red,
            data: ronaldo
          }
        ]
      },
      options: options
    })
    chartFilled.options.tooltips.mode = 'index'
    chartFilled.update()
