import React from 'react';
import { shallow } from 'enzyme';
import FieldForm from './FieldForm';

describe('FieldForm', () => {
  test('matches snapshot', () => {
    const wrapper = shallow(<FieldForm />);
    expect(wrapper).toMatchSnapshot();
  });
});
