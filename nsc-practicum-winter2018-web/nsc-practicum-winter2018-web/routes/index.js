var express = require('express');
var router = express.Router();

router.get('/message', function(req, res, next) {
  res.json('Welcome To React from routes/index.js');
});

module.exports = router;
