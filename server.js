const express = require('express')
const path = require('path')

const app = require('./api/app');
const port = process.env.PORT || 4000

app.use(express.static('dist'))

app.get('*', (req, res) => {
    res.sendFile(path.resolve(__dirname, './dist'))
})

app.listen(port, () => {
    console.log(`Server running on port ${port}`);
})