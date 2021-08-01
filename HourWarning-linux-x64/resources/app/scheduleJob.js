const btnStart = document.querySelector("#btnStart");

function showAtEachOneHour() {
  btnStart.setAttribute("hidden", true);
  let time = 3600;
  const timeInterval = setInterval(() => {
    document.getElementById("hourCountdown").innerHTML = time -= 1;
    if (time == 0) {
      alert("Tá na hora de descansar um pouco ,_,");
      btnStart.removeAttribute("hidden");
      clearInterval(timeInterval);
    }
  }, 1000);
}

btnStart.addEventListener("click", showAtEachOneHour);
