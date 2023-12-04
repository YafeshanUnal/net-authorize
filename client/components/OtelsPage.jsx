import { useState } from "react";
import axios from "axios";

const OtelsPage = () => {
	const [otels, setOtels] = useState([]);
	const [message, setMessage] = useState("");
	const handlePress = () => {
		axios
			.get("http://localhost:5090/crawlwithAuth", {
				headers: {
					"X-Hash-Key": "088d310940808a7a6910fa94bca59e75",
					// networkde görünmeyen header
				},
			})
			.then((response) => {
				console.log("response", response);
				setOtels(response.data);
			});

		console.log("otels", otels);
	};
	const handlePress2 = () => {
		axios
			.get("http://localhost:5090/crawlwithAuth", {})
			.then((response) => {
				console.log("response", response);
			})
			.catch((err) => {
				console.log("err", err);
				setMessage(err.message);
			});

		console.log("otels", otels);
	};
	return (
		<main className="flex min-h-screen flex-col items-center justify-center p-24">
			<button onClick={handlePress} className="font-bold text-3xl">
				Get Otels
			</button>
			<button onClick={handlePress2} className="font-bold text-3xl">
				Get Otels not auth
			</button>
			<div className="flex flex-col items-center justify-center text-white">
				{otels.map((otel) => (
					<div className="flex flex-col items-center text-white">
						<h1 className="text-2xl">{otel}</h1>
					</div>
				))}
				<h1 className="text-2xl">{message}</h1>
			</div>
		</main>
	);
};

export default OtelsPage;
