// const schedule = require("node-schedule");

// function showAtEachHour() {
//   let j = schedule.scheduleJob("* * * * *", function () {
//     alert("Tá na hora de descansar um pouco ,_,");
//   });
// }

function showAtEachOneHour() {
  document.querySelector(".btn-start").setAttribute("hidden", true);
  let time = 3600;
  const timeInterval = setInterval(() => {
    document.getElementById("hour-countdown").innerHTML = time -= 1;
    if (time == 0) {
      alert("Tá na hora de descansar um pouco ,_,");
      document.querySelector(".btn-start").removeAttribute("hidden");
      clearInterval(timeInterval);
    }
  }, 1000);
}

document
  .querySelector(".btn-start")
  .addEventListener("click", showAtEachOneHour);
