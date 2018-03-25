/* Dateparser.js
This is admin-on-rest's extra component to parse dates. */

const _tz_offset = new Date().getTimezoneOffset() / 60;
export const DateParser = v => {
  const regexp = /(\d{4})-(\d{2})-(\d{2})/
  var match = regexp.exec(v);
  if (match === null) return;

  var year = match[1];
  var month = match[2];
  var day = match[3];

  if (_tz_offset < 0) {
    // negative offset means our picked UTC date got converted to previous day
    var date = new Date(v);
    date.setDate(date.getDate() + 1);
    match = regexp.exec(date.toISOString())
    year = match[1];
    month = match[2];
    day = match[3];
  }
  const d = [year, month, day].join("-");
  return d;
};
