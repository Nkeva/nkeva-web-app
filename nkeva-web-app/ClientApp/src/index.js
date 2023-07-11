import React, { Suspense } from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';

ReactDOM.createRoot(document.getElementById('root')).render(
    <Suspense fallback={<div>Loading...</div>}>
        <App />
    </Suspense>
);
