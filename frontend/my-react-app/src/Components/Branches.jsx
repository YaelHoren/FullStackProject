import React from 'react';

const branches = [
  {
    name: 'סניף תל אביב',
    address: 'רחוב אלנבי 123, תל אביב',
    image: 'https://maps.googleapis.com/maps/api/staticmap?center=Tel+Aviv&zoom=15&size=600x300&key=YOUR_API_KEY',
  },
  {
    name: 'סניף ירושלים',
    address: 'רחוב יפו 45, ירושלים',
    image: 'https://maps.googleapis.com/maps/api/staticmap?center=Jerusalem&zoom=15&size=600x300&key=YOUR_API_KEY',
  },

  {
    name: 'סניף חיפה',
    address: 'רחוב הרצל 78, חיפה',
    image: 'https://maps.googleapis.com/maps/api/staticmap?center=Haifa&zoom=15&size=600x300&key=YOUR_API_KEY',
  },
];

const Branches = () => {
  return (
    <div style={styles.container}>
      <h1 style={styles.title}>רשימת סניפים</h1>
      <div style={styles.branchesList}>
        {branches.map((branch, index) => (
          <div key={index} style={styles.branch}>
            <h2 style={styles.branchName}>{branch.name}</h2>
            <p style={styles.address}>{branch.address}</p>
            <img src={branch.image} alt={branch.name} style={styles.image} />
          </div>
        ))}
      </div>
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
  branchesList: {
    display: 'flex',
    flexWrap: 'wrap',
    justifyContent: 'center',
  },
  branch: {
    margin: '20px',
    border: '1px solid #ddd',
    borderRadius: '5px',
    padding: '20px',
    maxWidth: '400px',
    textAlign: 'center',
  },
  branchName: {
    fontSize: '24px',
    fontWeight: 'bold',
    marginBottom: '10px',
  },
  address: {
    fontSize: '18px',
    marginBottom: '15px',
  },
  image: {
    width: '100%',
    borderRadius: '5px',
  },
};

export default Branches;