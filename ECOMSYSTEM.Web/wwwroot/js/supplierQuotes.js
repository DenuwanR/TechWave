<script>
    async function fetchSupplierQuotes(userId) {
        try {
            const response = await fetch(`/api/SupplierQuoteDetails/${userId}`);
    if (!response.ok) {
                throw new Error(`Error: ${response.statusText}`);
            }
    const data = await response.json();
    renderSupplierQuotes(data);
        } catch (error) {
        console.error("Failed to fetch supplier quotes:", error);
        }
    }

    function renderSupplierQuotes(quotes) {
        const tableBody = document.querySelector("#quotesTableBody");
    tableBody.innerHTML = "";

        quotes.forEach(quote => {
            const row = `
    <tr>
        <td>${quote.itemName}</td>
        <td>${quote.itemDescription}</td>
        <td>${quote.userName || "N/A"}</td>
        <td>${quote.mobileNo || "N/A"}</td>
        <td>${quote.quotationAmount}</td>
    </tr>
    `;
    tableBody.insertAdjacentHTML("beforeend", row);
        });
    }

    // Trigger the fetch with a sample userId
    fetchSupplierQuotes(4); // Replace with dynamic userId if needed
</script>
