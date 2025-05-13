export const fetchData = async () => {
    return new Promise((resolve, reject) => {
        setTimeout(async () => {
            try {
                if (Math.random() < 0.1) {
                    throw new Error("Simulated network error");
                }
                const response = await fetch('http://localhost:5067/api/Customer');
                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                }
                const result = await response.json();
                resolve(result);
            } catch (error) {
                reject(error.message);
            }
        }, 1000);
    });
};