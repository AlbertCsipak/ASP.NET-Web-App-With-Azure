/*Navbar*/
window.addEventListener("scroll", function() {
	document.querySelector("nav").classList.toggle("sticky", window.scrollY > 0);
})

/*Mobile-nav*/
let toggler = 0;
function menuToggle() {

	if (toggler > 1) {
		toggler = 0;
	}

	if (toggler == 0) {
		document.getElementById("dropdown").style.display = "flex";
		document.getElementById("dropdown").style.animationName = "floatdown";
		document.getElementById("menuIcon").style.animationName = "rotate";
		document.querySelector("body").classList.toggle("bodyFlow");
		toggler++;
	}
	else {
		document.getElementById("dropdown").style.animationName = "floatup";
		document.getElementById("menuIcon").style.animationName = "rotateback";
		document.querySelector("body").classList.toggle("bodyFlow");
		toggler++;
	}
}

/*SlideShow*/

let slideIndex = 1;
slideShow(slideIndex);

function slideShow(n) {
	slideIndex += n;

	document.getElementById("hero").classList.remove("bgfadein");
	document.getElementById("hero").classList.add("bgfadeout");

	if (slideIndex > 3) {
		slideIndex = 1
	}

	if (slideIndex < 1) {
		slideIndex = 3
	}

	if (slideIndex == 1) {
		setTimeout(() => {
			document.getElementById("hero").classList.remove("hero2", "hero3");
			document.getElementById("hero").classList.add("hero1");
			document.getElementById("hero").classList.remove("bgfadeout");
			document.getElementById("hero").classList.add("bgfadein");
		}, 300);

	}
	else if (slideIndex == 2) {
		setTimeout(() => {
			document.getElementById("hero").classList.remove("hero1", "hero3");
			document.getElementById("hero").classList.add("hero2");
			document.getElementById("hero").classList.remove("bgfadeout");
			document.getElementById("hero").classList.add("bgfadein");
		}, 300);

	}
	else if (slideIndex == 3) {
		setTimeout(() => {
			document.getElementById("hero").classList.remove("hero2", "hero1");
			document.getElementById("hero").classList.add("hero3");
			document.getElementById("hero").classList.remove("bgfadeout");
			document.getElementById("hero").classList.add("bgfadein");
		}, 300);

	}
}

/*Reviews*/

showReviews(2);

function showReviews(n) {
	document.getElementById("rb1").style.backgroundColor = "#e5e5e5";
	document.getElementById("rb2").style.backgroundColor = "#e5e5e5";
	document.getElementById("rb3").style.backgroundColor = "#e5e5e5";
	if (n == 1) {
		document.getElementById("reviews").textContent = "Javítás, mentés megfizethető áron, megbízható minőségben!";
		document.getElementById("rb1").style.backgroundColor = "#014F9C";
	}
	else if (n == 2) {
		document.getElementById("reviews").textContent = "Végre egy megbizható szerelőbrigád.";
		document.getElementById("rb2").style.backgroundColor = "#014F9C";
	}
	else if (n == 3) {
		document.getElementById("reviews").textContent = "Mitsubishi élménykörre is elvisznek azt mondták. :)";
		document.getElementById("rb3").style.backgroundColor = "#014F9C";
	}
}


/*Main img fade-in*/
const faders = document.querySelectorAll('.fade-in');

/*Ez mi??*/
const appearOptions = {
	root: null, //faszom sem tudja mi ez
	threshold: 0.30, //az itemnek mennyire kell benne lennie a viewportban
	rootMargin: "0px 0px 0px 0px", //ugyan az mint css-be
};

const appearOnScroll = new IntersectionObserver(
	function(
		entries, appearOnScroll
	) {
		entries.forEach(entry => {
			if (!entry.isIntersecting) {
				return;
			}
			else {
				entry.target.classList.add('appear');
				appearOnScroll.unobserve(entry.target);
			}
		})
	},
	appearOptions);

faders.forEach(fader => {
	appearOnScroll.observe(fader);
});