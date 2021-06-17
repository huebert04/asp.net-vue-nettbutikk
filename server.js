const express = require('express')
const path = require('path')

const app = express()
const port = 4000

app.use(express.static('dist'))

app.get('/api/hello', (req, res) => {
    res.send('Hei på deg')
})

app.get('*', (req, res) => {
    res.sendFile(path.resolve(__dirname, '/dist'))
})

app.listen(port, () => {
    console.log(`Server running on port ${port}`);
})