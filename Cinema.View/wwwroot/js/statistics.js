﻿function buildBarChart() {
    ctx = $('#bar_chart').getContext('2d');
    chart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: ['Hong Kong', 'Macau', 'Japan', 'Switzerland', 'Spain', 'Singapore'],
            datasets: [{
                label: 'Life expectancy',
                data: [84.308, 84.188, 84.118, 83.706, 83.5, 83.468],
                labelColor: '#fff',
                backgroundColor: [
                    'rgba(216, 27, 96, 0.6)',
                    'rgba(3, 169, 244, 0.6)',
                    'rgba(255, 152, 0, 0.6)',
                    'rgba(29, 233, 182, 0.6)',
                    'rgba(156, 39, 176, 0.6)',
                    'rgba(84, 110, 122, 0.6)'
                ],
                borderColor: [
                    'rgba(216, 27, 96, 1)',
                    'rgba(3, 169, 244, 1)',
                    'rgba(255, 152, 0, 1)',
                    'rgba(29, 233, 182, 1)',
                    'rgba(156, 39, 176, 1)',
                    'rgba(84, 110, 122, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            legend: {
                display: false
            },
            title: {
                display: true,
                text: 'Life Expectancy by Country',
                position: 'top',
                fontSize: 16,
                padding: 20
            },
            scales: {
                yAxes: [{
                    ticks: {
                        min: 75
                    }
                }]
            }
        }
    });
}

function buildPieChart(type) {
    ctx =  $('#' + type + '_chart').getContext('2d');
    chart = new Chart(ctx, {
        type: type,
        data: {
            labels: ['Dairy', 'Fruits', 'Lean meats', 'Vegetables', 'Whole grains'],
            datasets: [{
                data: [27.92, 17.53, 14.94, 26.62, 12.99],
                backgroundColor: ['#e91e63', '#00e676', '#ff5722', '#1e88e5', '#ffd600'],
                borderWidth: 0.5 ,
                borderColor: '#ddd'
            }]
        },
        options: {
            title: {
                display: true,
                text: 'Recommended Daily Diet',
                position: 'top',
                fontSize: 16,
                fontColor: '#fff',
                padding: 20
            },
            legend: {
                display: true,
                position: 'bottom',
                labels: {
                    boxWidth: 20,
                    fontColor: '#fff',
                    padding: 15
                }
            },
            tooltips: {
                enabled: false
            },
            plugins: {
                datalabels: {
                    color: '#fff',
                    textAlign: 'center',
                    font: {
                        lineHeight: 1.6
                    },
                    formatter: function(value, ctx) {
                        return ctx.chart.data.labels[ctx.dataIndex] + '\n' + value + '%';
                    }
                }
            }
        }
    });
}