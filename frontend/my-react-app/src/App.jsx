import { useState } from 'react';
import './App.css';
import Customer from './Components/Customer'; // ייבוא קומפוננטת לקוח
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import NavBar from './Components/NavBar'; // ייבוא ניווט
import PersonalArea from './Components/PersonalArea'; // ייבוא אזור אישי
import Branches from './Components/Branches'; // ייבוא קומפוננטת סניפים
import HomePage from './Components/HomePage'; // ייבוא דף הבית

function App() {
  const [count, setCount] = useState(0);

  return (
    <>
      <Router>
        <NavBar />
        <Routes>
          {/* דף הבית */}
          <Route path="/" element={<HomePage />} />
          {/* דף אזור אישי */}
          <Route path="/personal-area/:id" element={<PersonalArea />} />
          {/* דף סניפים */}
          <Route path="/branches" element={<Branches />} />
        </Routes>
      </Router>
    </>
  );
}

export default App;

