import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const HomePage = () => {
  const [id, setId] = useState('');
  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();
    if (id) {
      navigate(`/personal-area/${id}`);
    } else {
      alert('אנא הזן תעודת זהות');
    }
  };

  return (
    <div style={styles.container}>
      <h1 style={styles.title}>ברוך הבא</h1>
      <form onSubmit={handleSubmit} style={styles.form}>
        <label style={styles.label}>
          תעודת זהות:
          <input
            type="text"
            value={id}
            onChange={(e) => setId(e.target.value)}
            style={styles.input}
            required
          />
        </label>
        <button type="submit" style={styles.button}>היכנס</button>
      </form>
    </div>
  );
};

const styles = {
  container: {
    textAlign: 'center',
    marginTop: '50px',
  },
  title: {
    fontSize: '36px',
    fontWeight: 'bold',
    marginBottom: '20px',
  },
  form: {
    display: 'inline-block',
    textAlign: 'center',
  },
  label: {
    display: 'block',
    marginBottom: '15px',
    fontSize: '18px',
  },
  input: {
    width: '300px',
    padding: '10px',
    fontSize: '16px',
    marginTop: '5px',
  },
  button: {
    marginTop: '20px',
    padding: '10px 20px',
    fontSize: '18px',
    backgroundColor: '#4CAF50',
    color: 'white',
    border: 'none',
    cursor: 'pointer',
  },
};

export default HomePage;